using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    internal interface ILogin
    {
        public Task<bool> Login(string userName, string password);
    }
}
