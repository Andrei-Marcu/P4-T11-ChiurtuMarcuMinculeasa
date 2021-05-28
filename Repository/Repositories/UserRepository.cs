using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public override void Create(User entity)
        {
            throw new NotSupportedException("Users should be created with User Manager instead");
        }

        public override void Update(User entity)
        {
            throw new NotSupportedException("Users should be updated with User Manager instead");
        }
    }
}
