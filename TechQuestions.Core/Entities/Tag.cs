using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechQuestions.Core.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; }

        public Tag(string name) 
        { 
            Guard.Against.NullOrEmpty(name, nameof(name));

            Name = name;
        }
    }
}
