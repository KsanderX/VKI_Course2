using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.DataBase;

namespace Example.Service
{
    public interface IIndentService
    {
        public List<Indent> GetIndent(int userId);
        public Indent GetIndetsById(string id, int userId);
    }
}
