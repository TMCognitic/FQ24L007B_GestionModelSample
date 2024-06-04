using DalSample = FQ24L007B_GestionModelSample.Dal.Entities.Sample;
using BllSample = FQ24L007B_GestionModelSample.Bll.Entities.Sample;

namespace FQ24L007B_GestionModelSample.Bll.Mappers
{
    internal static class Mappers
    {
        internal static DalSample ToDal(this BllSample entity)
        {
            return new DalSample() { Id = entity.Id, Text = entity.Text };
        }

        internal static BllSample ToBll(this DalSample entity)
        {
            return new BllSample(entity.Id, entity.Text);
        }
    }
}
