using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQ24L007B_GestionModelSample.Bll.Entities
{
    public class Sample
    {
        public int Id { get; }
        public string Text { get; set; }

        public Sample(string text)
        {
            Text = text;
        }

        internal Sample(int id, string text) : this(text)
        {
            Id = id;
        }
    }
}
