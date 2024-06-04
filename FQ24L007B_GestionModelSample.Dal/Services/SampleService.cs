using FQ24L007B_GestionModelSample.Dal.Entities;
using FQ24L007B_GestionModelSample.Dal.Mappers;
using FQ24L007B_GestionModelSample.Dal.Repositories;
using System.Data.Common;
using Tools.Database;

namespace FQ24L007B_GestionModelSample.Dal.Services
{
    public class SampleService : ISampleRepository
    {
        public readonly DbConnection _dbConnection;

        public SampleService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Sample> Get()
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("SELECT Id, Text FROM Sample;", dr => dr.ToSample());
        }

        public Sample? Get(int id)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("SELECT Id, Text FROM Sample WHERE Id = @Id;", dr => dr.ToSample(), parameters: new { id }).SingleOrDefault();
        }

        public void Insert(Sample sample)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("INSERT INTO Sample (Text) VALUES (@Text)", parameters: new { sample.Text });
        }

        public void Update(Sample sample)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("UPDATE Sample SET Text = @Text WHERE Id = @Id", parameters: sample);
        }

        public void Delete(int id)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("DELETE FROM Sample WHERE Id = @Id;", parameters: new { id });
        }
    }
}
