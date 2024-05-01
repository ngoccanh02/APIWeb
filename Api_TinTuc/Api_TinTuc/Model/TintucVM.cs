using System.ComponentModel.DataAnnotations.Schema;

namespace Api_TinTuc.Model
{
    public class TintucVM
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
