using Tools.CQS.Commands;

namespace FQ24L007B_GestionModelSample.Domain.Commands
{
    public class DeleteSampleCommand : ICommandDefinition
    {
        public int Id { get; }

        public DeleteSampleCommand(int id)
        {
            Id = id;
        }
    }
}
