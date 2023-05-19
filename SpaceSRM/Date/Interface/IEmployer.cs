using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    public interface IEmployer
    {
        public Task<string> AddEmployer(string name, string surNeme, string phone);
        public Task<List<Employer>> GetEmployersQuick();
        public Task<string> DeleteEmployer(int id);
        public Task<string> EditEmployer(Employer employer);

    }
}