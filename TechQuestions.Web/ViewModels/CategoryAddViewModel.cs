using System.ComponentModel.DataAnnotations;

namespace TechQuestions.Web.ViewModels
{
    public class CategoryAddViewModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
    }
}
