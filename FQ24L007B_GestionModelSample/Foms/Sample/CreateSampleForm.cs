using System.ComponentModel.DataAnnotations;

namespace FQ24L007B_GestionModelSample.Foms.Sample
{
    public class CreateSampleForm
    {
        [Required]
        public string Text { get; set; }
    }
}
