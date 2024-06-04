using FQ24L007B_GestionModelSample.Domain.Commands;
using FQ24L007B_GestionModelSample.Domain.Entities;
using FQ24L007B_GestionModelSample.Domain.Mappers;
using FQ24L007B_GestionModelSample.Domain.Queries;
using FQ24L007B_GestionModelSample.Domain.Repositories;
using System.Data.Common;
using Tools.CQS.Commands;
using Tools.Database;

namespace FQ24L007B_GestionModelSample.Domain.Services
{
    public class SampleService : ISampleRepository
    {
        private readonly DbConnection _dbConnection;

        public SampleService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Sample> Execute(GetSamplesQuery query)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("Select Id, Text FROM Sample;", dr => dr.ToSample());
        }

        public Sample? Execute(GetSampleByIdQuery query)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteReader("Select Id, Text FROM Sample WHERE Id = @Id;", dr => dr.ToSample(), false, query).SingleOrDefault();
        }

        public CommandResult Execute(CreateSampleCommand command)
        {

            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("INSERT INTO Sample (Text) VALUES (@Text);", parameters: command);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }

        public CommandResult Execute(UpdateSampleCommand command)
        {
            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("UPDATE Sample SET Text = @Text WHERE Id = @Id;", parameters: command);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }

        public CommandResult Execute(DeleteSampleCommand command)
        {
            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("DELETE FROM Sample WHERE Id = @Id;", parameters: command);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }
    }
}
