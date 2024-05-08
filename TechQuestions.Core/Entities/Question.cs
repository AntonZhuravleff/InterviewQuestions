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
        private readonly List<Tag> _tags = new List<Tag>();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        public int CategoryId { get; set; }
        public Category Category { get; private set; }

        public string QuestionText { get; private set; }

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
            AppendTags(tags);
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

        public void AppendTag(Tag tagToAppend)
        {
            Guard.Against.Null(tagToAppend, nameof(tagToAppend));

            var existingTag = Tags.FirstOrDefault(t => t.Id == tagToAppend.Id);
            if (existingTag != null)
            {
                throw new ArgumentException("Tag with same Id has already been added to question");
            }

            _tags.Add(tagToAppend);
        }

        protected void AppendTags(IEnumerable<Tag> tags)
        {
            if (tags != null)
            {
                foreach (Tag tag in tags)
                {
                    AppendTag(tag);
                }
            }
        }
    }
}
