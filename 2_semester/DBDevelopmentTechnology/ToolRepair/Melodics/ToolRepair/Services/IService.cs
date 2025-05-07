using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRepair.Models;

namespace ToolRepair.Services
{
    public interface IService
    {
        Task<Client?> AuthenticateAsync(string login, string password);        
    }
}
