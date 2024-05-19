using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    public interface IClient
    {
        public Task<string> AddClient(string name, string SurNeme, string Phone);
        public Task<List<Client>> GetClientsQuick();
        public Task<List<Client>> GetClients();
        public Task<string> DeleteClient(int id);
        public Task<string> EditClient(Client client);
    }
}
