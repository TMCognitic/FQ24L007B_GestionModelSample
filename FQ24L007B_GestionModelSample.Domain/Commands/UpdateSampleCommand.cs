using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace FQ24L007B_GestionModelSample.Domain.Commands
{
    public class UpdateSampleCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Text { get; }
        public UpdateSampleCommand(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
