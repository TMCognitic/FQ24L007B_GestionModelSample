using FQ24L007B_GestionModelSample.Domain.Commands;
using FQ24L007B_GestionModelSample.Domain.Entities;
using FQ24L007B_GestionModelSample.Domain.Queries;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace FQ24L007B_GestionModelSample.Domain.Repositories
{
    public interface ISampleRepository :
        IQueryHandler<GetSamplesQuery, IEnumerable<Sample>>,
        IQueryHandler<GetSampleByIdQuery, Sample?>,
        ICommandHandler<CreateSampleCommand>,
        ICommandHandler<UpdateSampleCommand>,
        ICommandHandler<DeleteSampleCommand>
    {
    }
}
