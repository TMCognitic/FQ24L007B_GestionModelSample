using FQ24L007B_GestionModelSample.Domain.Entities;
using Tools.CQS.Queries;

namespace FQ24L007B_GestionModelSample.Domain.Queries
{
    public class GetSampleByIdQuery : IQueryDefinition<Sample?>
    {
        public int Id { get; }

        public GetSampleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
