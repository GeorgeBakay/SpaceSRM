
using Newtonsoft.Json;
using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace SpaceSRM.Date.Repository
{
    public class HttpClientRepository : IHttpClientSend
    {
        private HttpClient _httpClient;
        public HttpClientRepository()
        {
            _httpClient = new HttpClient();
            string connection = (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) ? "https://localhost:5555" : "https://localhost:7173";
            _httpClient.BaseAddress = new Uri(connection);
        }
        //Add запити


        public async Task<string> AddClient(Client client)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/AddClient", JsonContent.Create(client));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Seccses";
                }
                else
                {
                    return "Помилка";
                }
            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> AddEmployer(Employer employer)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/AddEmployer", JsonContent.Create(employer));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Seccses";
                }
                else
                {
                    return "Помилка";
                }
            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> AddService(Service service)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/AddService", JsonContent.Create(service));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Seccses";
                }
                else
                {
                    return "Помилка";
                }
            }
            catch(Exception ex)
            {
                return "Помилка " + ex.Message;
            }
            
        }

        public async Task<string> AddSetService(SetService setService)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/AddSetService", JsonContent.Create(setService));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Seccses";
                }
                else
                {
                    return "Помилка";
                }
            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        public async Task<string> AddRecord(Record record)
        {
            try
            {
                var json = JsonContent.Create(record);
                var response = await _httpClient.PostAsync("/api/Space/AddRecord", json);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Помилка " + response.ToString();
                }
            }
            catch(Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        public async Task<string> AddPhoto(int Id,Photo photo)
        {
            try
            {
                var json = JsonContent.Create(photo);
                var response = await _httpClient.PostAsync($"/api/Space/AddPhoto/{Id}", json);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Помилка " + response.ToString();
                }
            }
            catch(Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        //Delete запити
        public async Task<string> DeleteClient(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteClient/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";


            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> DeleteEmployer(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteEmployer/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";


            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> DeleteService(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteService/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                
                return "Помилка";
                

            }
            catch(Exception ex)
            {
                return "Помилка " + ex.Message;
            }


        }

        public async Task<string> DeleteSetService(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteSetService/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";


            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        public async Task<string> DeletePhoto(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeletePhoto/{Id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";


            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        public async Task<string> DeleteRecord(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteRecord/{Id}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";


            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        //Edit запити

        public async Task<string> EditClient(Client client)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/EditClient", JsonContent.Create(client));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";

            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> EditService(Service service)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/EditService", JsonContent.Create(service));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                
                return "Помилка";
                
            }
            catch(Exception ex)
            {
                return "Помилка " + ex.Message;
            }
            
        }

        public async Task<string> EditSetService(SetService setService)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/EditSetService", JsonContent.Create(setService));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";

            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        public async Task<string> EditEmployer(Employer employer)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/EditEmployer", JsonContent.Create(employer));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";

            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }
        public async Task<string> EditRecord(Record record)
        {
            try
            {
                var response = await _httpClient.PostAsync("/api/Space/EditRecord", JsonContent.Create(record));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Помилка";

            }
            catch (Exception ex)
            {
                return "Помилка " + ex.Message;
            }
        }

        //Get запити

        public async Task<List<Client>> GetClientsQuick()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetClientsQuick");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Client>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new List<Client>();
            }
        }

        public async Task<List<Employer>> GetEmployersQuick()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetEmployersQuick");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Employer>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new List<Employer>();
            }
        }

        public async Task<List<Service>> GetServicesQuick()
        {
        
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetServicesQuick");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Service>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new List<Service>();
            }
        }

        public async Task<List<SetService>> GetSetServices()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetSetServices");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<SetService>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new List<SetService>();
            }
        }

        public async Task<List<Record>> GetRecordsQuick()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetRecordsQuick");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Record>>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new List<Record>();
            }
        }

        public async Task<Record> GetRecord(int Id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Space/GetRecord/{Id}");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Record>(json);
                return result;
            }
            catch
            {
                return new Record();
            }
        }

        public async Task<Photo> GetPhoto(int Id, int NumPhoto)
        {
            try
            {
                
                using (var response = await _httpClient.GetAsync($"/api/Space/GetPhoto/{Id}?numPhoto={NumPhoto}"))
                {
                     response.EnsureSuccessStatusCode();

                     if (response.IsSuccessStatusCode)
                     {
                          return await response.Content.ReadFromJsonAsync<Photo>();
                     }
                    return new Photo();
                }
             }
            catch
            {
                return new Photo();
            }
        }
    }
}
