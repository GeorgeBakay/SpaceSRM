

using SpaceSRM.Date.Interface;
using SpaceSRM.Models;

namespace SpaceSRM.Date.Repository
{
    public class RecordRepository : IRecord
    {
        private readonly IHttpClientSend _httpClientSend = new HttpClientRepository();

        public async Task<string> AddPhoto(int Id, Photo photo)
        {
            string response = await _httpClientSend.AddPhoto(Id,photo);
            return response;
        }

        public async Task<string> AddRecord(Record record)
        {
            string response = await _httpClientSend.AddRecord(record);
            return response;
        }

        public async Task<string> DeletePhoto(int Id)
        {
            string response = await _httpClientSend.DeletePhoto(Id);
            return response;
        }

        public async Task<string> DeleteRecord(int Id)
        {
            string response = await _httpClientSend.DeleteRecord(Id);
            return response;
        }

        public async Task<string> EditRecord(Record record) 
        {
            string response = await _httpClientSend.EditRecord(record);
            return response;
        }

        public async Task<Photo> GetPhoto(int Id, int NumPhoto)
        {
            Photo response = await _httpClientSend.GetPhoto(Id,NumPhoto);
            return response;

        }

        public async Task<Record> GetRecord(int Id)
        {
            Record response = await _httpClientSend.GetRecord(Id);
            return response;
        }
        public async Task<List<Record>> GetRecordsWithColor()
        {
            List<Record>? records = await _httpClientSend.GetRecords();
            if (records != null)
            {

                foreach (Record record in records)
                {
                    switch (record.Status)
                    {
                        case Status.End:
                            record.ColorOfStatus = Color.FromArgb("#4ED16B");
                            record.StatusString = "Завершено";
                            break;
                        case Status.Work:
                            record.ColorOfStatus = Color.FromArgb("#CFD14E");
                            record.StatusString = "Робота";
                            break;
                        case Status.Abolition:
                            record.ColorOfStatus = Color.FromArgb("#FA6D6D");
                            record.StatusString = "Відмова";
                            break;
                        case Status.Wait:
                            record.ColorOfStatus = Color.FromArgb("#D1764E");
                            record.StatusString = "Запис";
                            break;
                    }
                }
                return records;
            }
            return new List<Record>();
            return records;
        }
        public async Task<List<Record>> GetRecords()
        {
            List<Record>? records = await _httpClientSend.GetRecords();
            return records;
        }
        public async Task<List<Work>> GetWorks()
        {
            List<Work>? records = await _httpClientSend.GetWorks();
            return records;
        }
        public async Task<List<Record>> GetRecordsQuick()
        {
            try
            {
                List<Record>? records = await _httpClientSend.GetRecordsQuick();
                if(records != null)
                {
                    
                    foreach (Record record in records)
                    {
                        switch(record.Status)
                        {
                            case Status.End:
                                record.ColorOfStatus = Color.FromArgb("#4ED16B");
                                record.StatusString = "Завершено";
                                break;
                            case Status.Work:
                                record.ColorOfStatus = Color.FromArgb("#CFD14E");
                                record.StatusString = "Робота";
                                break;
                            case Status.Abolition:
                                record.ColorOfStatus = Color.FromArgb("#FA6D6D");
                                record.StatusString = "Відмова";
                                break;
                            case Status.Wait:
                                record.ColorOfStatus = Color.FromArgb("#D1764E");
                                record.StatusString = "Запис";
                                break;
                        }
                    }
                    return records;
                }
                return new List<Record>();

            }
            catch
            {
                return new List<Record>();
            }
        }
    }
}
