using FQ24L007B_GestionModelSample.Dal.Entities;
using System.Data;

namespace FQ24L007B_GestionModelSample.Dal.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Sample ToSample(this IDataRecord record)
        {
            return new Sample()
            {
                Id = (int)record["Id"],
                Text = (string)record["Text"]
            };
        }
    }
}
