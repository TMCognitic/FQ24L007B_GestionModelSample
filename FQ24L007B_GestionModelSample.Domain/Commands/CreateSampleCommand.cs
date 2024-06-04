using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace FQ24L007B_GestionModelSample.Domain.Commands
{
    public class CreateSampleCommand : ICommandDefinition
    {
        public string Text { get; }

        public CreateSampleCommand(string text)
        {
            Text = text;
        }
    }
}
