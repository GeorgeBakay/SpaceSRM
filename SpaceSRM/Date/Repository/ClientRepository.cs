using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Repository
{
    public class ClientRepository : IClient
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> AddClient(string name, string surNeme, string phone)
        {
            Client client = new Client() {
                Name = name,
                SurName = surNeme,
                Phone = phone
            };
            
            string response = await _httpClientSend.AddClient(client);
            if (response == "Seccses")
            {
                return "Seccses";
            }
            else
            {
                return response;
            }
        }

        public async Task<string> DeleteClient(int id)
        {

            string response = await _httpClientSend.DeleteClient(id);
            return response;
        }

        public async Task<string> EditClient(Client client)
        {
            string response = await _httpClientSend.EditClient(client);
            return response;
        }

        public async Task<List<Client>> GetClientsQuick()
        {
            List<Client> clients = await _httpClientSend.GetClientsQuick();
            return clients;
        }
    }
}
