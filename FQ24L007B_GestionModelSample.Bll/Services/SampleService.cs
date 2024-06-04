using FQ24L007B_GestionModelSample.Bll.Entities;
using FQ24L007B_GestionModelSample.Bll.Mappers;
using FQ24L007B_GestionModelSample.Bll.Repositories;


using DalSample = FQ24L007B_GestionModelSample.Dal.Entities.Sample;
using IDalSampleRepository = FQ24L007B_GestionModelSample.Dal.Repositories.ISampleRepository;

namespace FQ24L007B_GestionModelSample.Bll.Services
{
    public class SampleService : ISampleRepository
    {
        private readonly IDalSampleRepository _dalRepository;

        public SampleService(IDalSampleRepository dalRepository)
        {
            _dalRepository = dalRepository;
        }        

        public IEnumerable<Sample> Get()
        {
            return _dalRepository.Get().Select(s => s.ToBll());
        }

        public Sample? Get(int id)
        {
            return _dalRepository.Get(id)?.ToBll();
        }

        public void Insert(Sample sample)
        {
            _dalRepository.Insert(sample.ToDal());
        }

        public void Update(int id, Sample sample)
        {
            DalSample dalSample = sample.ToDal();
            dalSample.Id = id;

            _dalRepository.Update(dalSample);
        }

        public void Delete(int id)
        {
            _dalRepository.Delete(id);
        }
    }
}
