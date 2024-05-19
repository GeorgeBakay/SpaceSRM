
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    internal interface IService
    {
        public Task<string> AddService(string name, string type, int price, int procent);
        public Task<List<Service>> GetServicesQuick();
        public Task<string> DeleteService(int id);
        public Task<string> EditService(Service service);
    }
}
