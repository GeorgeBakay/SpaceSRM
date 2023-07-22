using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Repository
{
    public class EmployerRepository : IEmployer
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> AddEmployer(string name, string surNeme, string phone)
        {
            Employer employer = new Employer()
            {
                Name = name,
                SurName = surNeme,
                Phone = phone
            };

            string response = await _httpClientSend.AddEmployer(employer);
            if (response == "Seccses")
            {
                return "Seccses";
            }
            else
            {
                return response;
            }
        }

        public async Task<string> DeleteEmployer(int id)
        {
            string response = await _httpClientSend.DeleteEmployer(id);
            return response;
        }

        public async Task<string> EditEmployer(Employer employer)
        {
            string response = await _httpClientSend.EditEmployer(employer);
            return response;
        }

        public async Task<List<Employer>> GetEmployers()
        {
            List<Employer> clients = await _httpClientSend.GetEmployers();
            return clients;
        }

        public async Task<List<Employer>> GetEmployersQuick()
        {
            List<Employer> clients = await _httpClientSend.GetEmployersQuick();
            return clients;
        }
    }
}
