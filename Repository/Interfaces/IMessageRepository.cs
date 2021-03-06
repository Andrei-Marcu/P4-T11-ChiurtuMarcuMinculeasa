using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Interfaces
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
    }
}
