using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
namespace SpaceSRM.Date.Repository
{
    public class CostRepository : ICost
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();

        public async Task<string> AddCost(Cost cost)
        {
            return await _httpClientSend.AddCost(cost);
        }

        public async Task<string> DeleteCost(int Id)
        {
            return await _httpClientSend.DeleteCost(Id);
        }

        public async Task<string> EditCost(Cost cost)
        {
            return await _httpClientSend.EditCost(cost);
        }

        public async Task<List<Cost>> GetCosts()
        {
            return await _httpClientSend.GetCosts();
        }
    }
}
