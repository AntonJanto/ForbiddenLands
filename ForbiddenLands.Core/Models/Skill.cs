using System;

namespace ForbiddenLands.Core.Models
{
    public class Skill
    {
        public Skill(string name, Attribute attribute)
        {
            Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
            Name = name;
        }

        public Attribute Attribute { get; set; }
        public virtual string Name { get; set; }
        public int Level { get; set; } = 0;
    }
}