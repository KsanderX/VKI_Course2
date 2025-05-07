using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolRepair.Models;

namespace ToolRepair.Services
{
    public class Service : IService
    {
        private readonly AganichevMusicToolsRepairContext _context;

        public Service(AganichevMusicToolsRepairContext context)
        {
            _context = context;
        }
        public async Task<Client?> AuthenticateAsync(string login, string password)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Логин == login && c.Пароль == password);
        }
    }
}
