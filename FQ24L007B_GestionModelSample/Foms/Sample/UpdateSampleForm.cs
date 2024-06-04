using System.ComponentModel.DataAnnotations;

namespace FQ24L007B_GestionModelSample.Foms.Sample
{
    public class UpdateSampleForm
    {
        [Required]
        public string Text { get; set; }
    }
}
