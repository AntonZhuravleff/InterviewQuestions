using Ardalis.GuardClauses;

namespace TechQuestions.Core.Entities
{
    public class Test : BaseEntity
    {
        private readonly List<Question> _questions = new List<Question>();
        public IReadOnlyCollection<Question> Questions => _questions.AsReadOnly();

        public int Count => _questions.Count;

        public string Name { get; set; }

        public Test(string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void AddQuestion(Question questionToAdd)
        {
            Guard.Against.Null(questionToAdd, nameof(questionToAdd));

            var existingQuestion = Questions.FirstOrDefault(q => q.Id == questionToAdd.Id);
            if (existingQuestion != null)
            {
                throw new ArgumentException("Qustion with same Id has already been added to test");
            }

            _questions.Add(questionToAdd);
        }
    }
}
