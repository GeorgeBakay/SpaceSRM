
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    public interface ISalary
    {
        public Task<string> AddSalary(Salary salary);
        public Task<string> DeleteSalary(int Id);
        public Task<string> EditSalary(Salary salary);
        public Task<List<Salary>> GetSalarysEmployer(int employerId);
        public Task<List<Salary>> GetSalarys();
    }
}
