using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using LibraryManagement.Utils.Services;
using LibraryManagement.Repository.Interfaces;

namespace LibraryManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICityService _cityService;
        private readonly IUserRepository _userRepository;

        public UserController(UserManager<User> userManager, ICityService cityService, IUserRepository userRepository)
        {
            _userManager = userManager;
            _cityService = cityService;
            _userRepository = userRepository;
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            User user;
            if (id == null)
            {
                user = await _userManager.GetUserAsync(User);
                ViewBag.id = user.Id;
            }
            else
            {
                if (!User.IsInRole("Administrator") && _userManager.GetUserId(User) != id.ToString())
                {
                    return Forbid();
                }
                ViewBag.id = id;
                user = await _userManager.FindByIdAsync(id.ToString());
            }

            if (user == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_cityService.GetCities(), nameof(City.CityID), nameof(City.Name));
            return View(new UserViewModel()
            {
                Email = user.Email,
                Username = user.UserName,
                Name = user.Name,
                CityID = user.CityID,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            });
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Administrator") && _userManager.GetUserId(User) != id.ToString())
            {
                return Forbid();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_cityService.GetCities(), nameof(City.CityID), nameof(City.Name));
            return View(new UserViewModel()
            {
                Email = user.Email,
                Username = user.UserName,
                Name = user.Name,
                CityID = user.CityID,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            });
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserViewModel userVM)
        {
            //Check permission
            if (!User.IsInRole("Administrator") && _userManager.GetUserId(User) != id.ToString())
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return NotFound();
                }

                //Check current password
                if (!await _userManager.CheckPasswordAsync(user, userVM.CurrentPassword))
                {
                    ModelState.AddModelError(nameof(UserViewModel.CurrentPassword), "Wrong password");
                    goto fail;
                }

                //Do we have a new password?
                if (!string.IsNullOrEmpty(userVM.Password))
                {
                    var passResult = await _userManager.ChangePasswordAsync(user, userVM.CurrentPassword, userVM.Password);
                    if (!passResult.Succeeded)
                    {
                        foreach (var err in passResult.Errors)
                        {
                            ModelState.AddModelError(nameof(UserViewModel.Password), err.Description);
                        }
                        goto fail;
                    }

                    //updating and checking if we failed
                    if (!await updateDetails(user, userVM))
                    {
                        //force reload from the database!!!
                        _userRepository.Reload(user);

                        var passResult2 = await _userManager.ChangePasswordAsync(user, userVM.Password, userVM.CurrentPassword);
                        if (!passResult2.Succeeded)
                        {
                            foreach (var err in passResult.Errors)
                            {
                                ModelState.AddModelError(String.Empty, err.Description);
                            }
                            goto fail;
                        }
                        goto fail;
                    }
                }
                //updating without new password
                else
                {
                    if (!await updateDetails(user, userVM))
                    {
                        goto fail;
                    }
                }
                return RedirectToAction(nameof(Details), id);
            }
        fail:
            ViewData["CityID"] = new SelectList(_cityService.GetCities(), nameof(City.CityID), nameof(City.Name));
            return View(userVM);
        }

        async Task<bool> updateDetails(User user, UserViewModel userVM)
        {
            user.Email = userVM.Email;
            user.UserName = userVM.Username;
            user.Name = userVM.Name;
            user.CityID = userVM.CityID;
            user.Address = userVM.Address;
            user.PhoneNumber = userVM.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return false;
            }
        }
    }
}
