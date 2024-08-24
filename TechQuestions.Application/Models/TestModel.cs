namespace TechQuestions.Application.Models
{
    public class TestModel : BaseModel
    {
        public List<QuestionModel> Questions = new List<QuestionModel>();
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
