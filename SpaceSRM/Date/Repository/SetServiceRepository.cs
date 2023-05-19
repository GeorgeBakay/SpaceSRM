using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Repository
{
    public class SetServiceRepository : ISetService
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> AddSetService(string name, List<Service> services, int discount)
        {
            SetService setService = new SetService()
            {
                Name = name,
                Services = services,
                Discount = discount
            };

            string response = await _httpClientSend.AddSetService(setService);
            if (response == "Seccses")
            {
                return "Seccses";
            }
            else
            {
                return response;
            }
        }

        public async Task<string> DeleteSetService(int id)
        {
            string response = await _httpClientSend.DeleteSetService(id);
            return response;
        }

        public async Task<string> EditSetService(SetService setService)
        {
            string response = await _httpClientSend.EditSetService(setService);
            return response;
        }

        public async Task<List<SetService>> GetSetServices()
        {
            List<SetService> setServices = await _httpClientSend.GetSetServices();
            return setServices;
        }
    }
}
