
using SpaceSRM.Date.Models;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Interface
{
    interface IHttpClientSend
    {
        //Запроси Послуги
        public Task<string> AddService(Service service);
        public Task<string> DeleteService(int id);
        public Task<List<Service>> GetServicesQuick();
        public Task<List<Service>> GetServices();
        public Task<string> EditService(Service service);

        //Запроси клієнт 
        public Task<string> AddClient(Client client);
        public Task<string> DeleteClient(int id);
        public Task<List<Client>> GetClientsQuick();
        public Task<List<Client>> GetClients();
        public Task<string> EditClient(Client client);

        //Запроси набір послуг
        public Task<string> AddSetService(SetService setService);
        public Task<string> DeleteSetService(int id);
        public Task<List<SetService>> GetSetServices();
        public Task<string> EditSetService(SetService setService);

        //Запроси робітники
        public Task<string> AddEmployer(Employer employer);
        public Task<string> DeleteEmployer(int id);
        public Task<List<Employer>> GetEmployersQuick();
        public Task<List<Employer>> GetEmployers();
        public Task<string> EditEmployer(Employer employer);


        //Методи для роботи з записами

        public Task<List<Record>> GetRecordsQuick();
        public Task<List<Record>> GetRecords();
        public Task<string> AddRecord(Record record);
        public Task<string> AddPhoto(int Id, Photo photo);
        public Task<Record> GetRecord(int Id);
        public Task<List<Work>> GetWorks();
        public Task<string> DeletePhoto(int Id);
        public Task<string> DeleteRecord(int Id);
        public Task<string> EditRecord(Record record);
        public Task<Photo> GetPhoto(int Id, int NumPhoto);

        //Методи взаємодії з витратами
        public Task<string> AddCost(Cost cost);
        public Task<List<Cost>> GetCosts();
        public Task<string> EditCost(Cost cost);
        public Task<string> DeleteCost(int Id);
        //Зарплати 
        public Task<string> AddSalary(Salary salary);
        public Task<string> DeleteSalary(int Id);
        public Task<string> EditSalary(Salary salary);
        public Task<List<Salary>> GetSalarysEmployer(int employerId);
        public Task<List<Salary>> GetSalarys();
        //Логінізація
        public Task<string> Login(User user);

    }
}
