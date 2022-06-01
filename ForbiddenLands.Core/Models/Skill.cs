namespace ForbiddenLands.Core.Models
{
    public abstract class Skill
    {
        public Skill(string name, Attribute attribute)
        {
            Attribute = attribute;
            Name = name;
        }

        public Attribute Attribute { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 0;
    }
}