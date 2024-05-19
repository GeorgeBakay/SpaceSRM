using System;
using SpaceSRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    internal interface ICost
    {
        public Task<string> AddCost(Cost cost);
        public Task<List<Cost>> GetCosts();
        public Task<string> DeleteCost(int Id);
        public Task<string> EditCost(Cost cost);
    }
}
