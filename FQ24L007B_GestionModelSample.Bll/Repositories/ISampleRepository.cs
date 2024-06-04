using FQ24L007B_GestionModelSample.Bll.Entities;

namespace FQ24L007B_GestionModelSample.Bll.Repositories
{
    public interface ISampleRepository
    {
        IEnumerable<Sample> Get();
        Sample? Get(int id);
        void Insert(Sample sample);
        void Update(int id, Sample sample);
        void Delete(int id);
    }
}
