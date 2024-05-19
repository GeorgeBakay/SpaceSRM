using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Repository
{
    public class ServiceRepository : IService
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> AddService(string name, string type, int price, int procent)
        {
            Service service = new Service();
            service.Name = name;
            service.Type = type;
            service.Price = price; 
            service.Procent = procent;
            string response = await _httpClientSend.AddService(service);
            if(response == "Seccses")
            {
                return "Seccses";
            }
            else
            {
                return response;
            }
        }
        public async Task<List<Service>> GetServicesQuick()
        {
            List<Service> services = await _httpClientSend.GetServicesQuick();
            return services;
        }
        public async Task<string> DeleteService(int id)
        {
            string response = await _httpClientSend.DeleteService(id);
            return response;
        }
        public async Task<string> EditService(Service service)
        {
            string response = await _httpClientSend.EditService(service);
            return response;
        }
    }
}
