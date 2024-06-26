﻿using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechQuestions.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Color { get; set; }
        public string ImageName { get; set; }
        
        public Category(string name, string color, string imageName)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(color, nameof(color));
            Guard.Against.NullOrEmpty(imageName, nameof(imageName));

            Name = name;
            Color = color;
            ImageName = imageName;
        }
    }
}
