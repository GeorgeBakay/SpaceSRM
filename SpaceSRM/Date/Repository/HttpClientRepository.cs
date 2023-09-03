
using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Models;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;



namespace SpaceSRM.Date.Repository
{
    public class propertyContractResolver : DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type t, JsonSerializerOptions o)
        {
            JsonTypeInfo type = base.GetTypeInfo(t, o);

            if (type.Kind == JsonTypeInfoKind.Object)
            {
                foreach (JsonPropertyInfo prop in type.Properties)
                {
                    prop.Name = prop.Name.ToUpperInvariant();
                }
            }

            return type;
        }
    }
    public class HttpClientRepository : IHttpClientSend
    {
        private HttpClient _httpClient;
        private static string _token = "";
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            TypeInfoResolver = new propertyContractResolver(),
            PropertyNameCaseInsensitive = true ,// Якщо ви хочете ігнорувати регістр імен властивостей
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };
        private static string phoneNumberOfUser = "";
        public HttpClientRepository()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
            };


            _httpClient = new HttpClient(handler);
            //string connection = (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) ? "https://localhost:5555" : "https://localhost:7173";
            string connection = (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) ? "https://user29121.realhost-free.net" : "https://user29121.realhost-free.net";
            _httpClient.BaseAddress = new Uri(connection);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        }
        //Add запити


        public async Task<string> AddClient(Client client)
        {
            try
            {
                var clientJson = JsonSerializer.Serialize(client, options);
                var content = new StringContent(clientJson, Encoding.UTF8, "application/json");
         
                var response = await _httpClient.PostAsync("/api/Space/AddClient", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Seccses";
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
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
                var employerJson = JsonSerializer.Serialize(employer, options);
                var content = new StringContent(employerJson, Encoding.UTF8, "application/json");
    

                var response = await _httpClient.PostAsync("/api/Space/AddEmployer", content);

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
                var serviceJson = JsonSerializer.Serialize(service, options);
                var content = new StringContent(serviceJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Space/AddService", content);

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
                var setServiceJson = JsonSerializer.Serialize(setService, options);
                var content = new StringContent(setServiceJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Space/AddSetService", content);

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
                string recordJson = JsonSerializer.Serialize(record,options);
                var content = new StringContent(recordJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Space/AddRecord", content);

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
                var photoJson = JsonSerializer.Serialize(photo, options);
                var content = new StringContent(photoJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Space/AddPhoto/{Id}", content);
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
        public async Task<string> AddCost(Cost cost)
        {
            try
            {
                var costJson = JsonSerializer.Serialize(cost, options);
                var content = new StringContent(costJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Space/AddCost", content);

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

        public async Task<string> AddSalary(Salary salary)
        {
            try
            {
                var salaryJson = JsonSerializer.Serialize(salary, options);
                var content = new StringContent(salaryJson, Encoding.UTF8, "application/json");
       
                var response = await _httpClient.PostAsync("/api/Space/AddSalary", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "ok";
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
            catch (Exception ex)
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
        public async Task<string> DeleteCost(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteCost/{Id}");
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
        public async Task<string> DeleteSalary(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Space/DeleteSalary/{Id}");
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
                var clientJson = JsonSerializer.Serialize(client, options);
                var content = new StringContent(clientJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/Space/EditClient", content);
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
                var serviceJson = JsonSerializer.Serialize(service, options);
                var content = new StringContent(serviceJson, Encoding.UTF8, "application/json");


                var response = await _httpClient.PostAsync("/api/Space/EditService", content);
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

                var setServiceJson = JsonSerializer.Serialize(setService, options);
                var content = new StringContent(setServiceJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Space/EditSetService", content);
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
                var employerJson = JsonSerializer.Serialize(employer, options);
                var content = new StringContent(employerJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Space/EditEmployer", content);
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
                var recordJson = JsonSerializer.Serialize(record, options);
                var content = new StringContent(recordJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Space/EditRecord", content);
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
        public async Task<string> EditCost(Cost cost)
        {
            try
            {
                var costJson = JsonSerializer.Serialize(cost, options);
                var content = new StringContent(costJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Space/EditCost", content);
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
        public async Task<string> EditSalary(Salary salary)
        {
            try
            {
                var salaryJson = JsonSerializer.Serialize(salary, options);
                var content = new StringContent(salaryJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Space/EditSalary", content);
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
                var result = JsonSerializer.Deserialize<List<Client>>(json, options);

                return result;
            }
            catch 
            {
                return new List<Client>();
            }
        }
        public async Task<List<Client>> GetClients()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetClients");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Client>>(json, options);
              
                return result;
            }
            catch 
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
                var result = JsonSerializer.Deserialize<List<Employer>>(json, options);
             
                return result;
            }
            catch 
            {
                return new List<Employer>();
            }
        }
        public async Task<List<Employer>> GetEmployers()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetEmployers");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Employer>>(json, options);
               
                return result;
            }
            catch 
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
                var result = JsonSerializer.Deserialize<List<Service>>(json, options);
                
                return result;
            }
            catch 
            {
                return new List<Service>();
            }
        }
        public async Task<List<Service>> GetServices()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetServices");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Service>>(json, options);

                return result;
            }
            catch 
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
                var result = JsonSerializer.Deserialize<List<SetService>>(json,options);
                return result;
            }
            catch 
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
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                using (MemoryStream stream = new MemoryStream(jsonBytes))
                {
                    // Асинхронна десеріалізація з Stream
                    var result = await JsonSerializer.DeserializeAsync<List<Record>>(stream, options);
                    return result;
                    // Ваш код для подальшої роботи з результатом
                }
                
                
            }
            catch 
            {
                return new List<Record>();
            }
        }
        public async Task<List<Record>> GetRecords()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetRecords");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Record>>(json, options);

                return result;
            }
            catch 
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
                var result = JsonSerializer.Deserialize<Record>(json, options);
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

        public async Task<List<Work>> GetWorks()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetWorks");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Work>>(json, options);
                return result;
            }
            catch 
            {
                return new List<Work>();
            }
        }



        public async Task<List<Cost>> GetCosts()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Space/GetCosts");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Cost>>(json, options);
                return result;
            }
            catch 
            {
                return new List<Cost>();
            }
        }
        public async Task<List<Salary>> GetSalarysEmployer(int employerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Space/GetSalarysEmployer/{employerId}");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Salary>>(json, options);
                return result;
            }
            catch 
            {
                 return new List<Salary>();
            }
        }
        public async Task<List<Salary>> GetSalarys()
        {
            try
            {

                var response = await _httpClient.GetAsync($"/api/Space/GetSalarys");
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Salary>>(json, options);
                return result;
            }
            catch
            {
                return new List<Salary>();
            }
        }

        //Логінізація
        public async Task<string> Login(User user)
        {
            try
            {
                var userJson = JsonSerializer.Serialize(user,options);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/Login", content);

                
               
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var tokenStr = await response.Content.ReadAsStringAsync();
                    _token = tokenStr.Trim('"');
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                    return "true";
                    
                }


                return "в try" + response.RequestMessage.ToString();
            }
            catch(Exception ex)
            {
                return "в catch" +  ex.Message.ToString();
            }
        }
       
    }
}
