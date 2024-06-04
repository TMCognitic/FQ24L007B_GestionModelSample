using FQ24L007B_GestionModelSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQ24L007B_GestionModelSample.Domain.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Sample ToSample(this IDataRecord record)
        {
            return new Sample((int)record["Id"], (string)record["Text"]);
        }
    }
}
