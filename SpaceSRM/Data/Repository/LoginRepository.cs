using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Repository
{
    
    internal class LoginRepository : ILogin
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();
        public async Task<string> Login(string _userName, string _password)
        {
            string result = await _httpClientSend.Login(new User {userName = _userName,password = _password });
            return result;
        }
    }
}
