using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    public interface ISetService
    {
        public Task<string> AddSetService(string name, List<Service> services, int discount);
        public Task<List<SetService>> GetSetServices();
        public Task<string> DeleteSetService(int id);
        public Task<string> EditSetService(SetService setService);
    }
}
