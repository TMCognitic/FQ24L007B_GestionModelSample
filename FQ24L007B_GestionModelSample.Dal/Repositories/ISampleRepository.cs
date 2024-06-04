using FQ24L007B_GestionModelSample.Dal.Entities;

namespace FQ24L007B_GestionModelSample.Dal.Repositories
{
    public interface ISampleRepository
    {
        IEnumerable<Sample> Get();
        Sample? Get(int id);
        void Insert(Sample sample);
        void Update(Sample sample);
        void Delete(int id);
    }
}
