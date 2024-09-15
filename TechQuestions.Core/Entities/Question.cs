using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace TechQuestions.Core.Entities
{
    public class Question : BaseEntity
    {
        private List<Tag> _tags = new List<Tag>();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        public int CategoryId { get; set; }
        public Category Category { get; private set; }
        public string QuestionText { get; private set; }
        public string? ShortAnswer { get; private set; }
        public string Answer { get; private set; }

        public Question(int categoryId, string questionText, string answer)
        {
            Guard.Against.Zero(categoryId, nameof(categoryId));

            CategoryId = categoryId;
            SetQuestionText(questionText);
            SetAnswer(answer);
        }

        public Question(int categoryId, string questionText, string answer, IEnumerable<Tag> tags)
        {
            Guard.Against.Zero(categoryId, nameof(categoryId));

            CategoryId = categoryId;
            SetQuestionText(questionText);
            SetAnswer(answer);
            SetTags(tags);
        }

        public Question(int categoryId, string questionText, string shortAnswer, string answer, IEnumerable<Tag> tags)
        {
            Guard.Against.Zero(categoryId, nameof(categoryId));

            CategoryId = categoryId;
            SetQuestionText(questionText);
            SetShortAnswer(shortAnswer);
            SetAnswer(answer);
            SetTags(tags);
        }

        public void SetQuestionText(string questionText)
        {
            Guard.Against.NullOrEmpty(questionText, nameof(questionText));

            QuestionText = questionText;
        }

        public void SetAnswer(string answer)
        {
            Guard.Against.NullOrEmpty(answer, nameof(answer));

            Answer = answer;
        }

        public void SetShortAnswer(string shortAnswer)
        {
            ShortAnswer = shortAnswer;
        }

        public void SetTags(IEnumerable<Tag> tags)
        {
            if (tags != null)
            {
                _tags = tags.ToList();
            }
        }
    }
}
