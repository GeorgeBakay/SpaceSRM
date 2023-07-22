using SpaceSRM.Date.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSRM.Models;

namespace SpaceSRM.Date.Repository
{
    public class SalaryRepository : ISalary
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> AddSalary(Salary salary)
        {
            return await _httpClientSend.AddSalary(salary);
        }

        public async Task<string> DeleteSalary(int Id)
        {
            return await _httpClientSend.DeleteSalary(Id);
        }

        public async Task<string> EditSalary(Salary salary)
        {
            return await _httpClientSend.EditSalary(salary);
        }

        public async Task<List<Salary>> GetSalarysEmployer(int employerId)
        {
            return await _httpClientSend.GetSalarysEmployer(employerId);
        }
    }
}
