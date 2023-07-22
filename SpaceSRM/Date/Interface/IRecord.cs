using SpaceSRM.Models;


namespace SpaceSRM.Date.Interface
{
    public interface IRecord
    {
        public Task<List<Record>> GetRecordsQuick();
        public Task<List<Record>> GetRecords();
        public Task<List<Work>> GetWorks();
        public Task<string> AddPhoto(int Id,Photo photo);
        public Task<string> AddRecord(Record record);
        public Task<Record> GetRecord(int Id);
        public Task<string> DeletePhoto(int Id);
        public Task<string> DeleteRecord(int Id);
        public Task<string> EditRecord(Record record);
        public Task<Photo> GetPhoto(int Id, int NumPhoto);
    }
}
