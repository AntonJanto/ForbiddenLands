namespace ForbiddenLands.Core.Models
{
    public abstract class Age
    {
        public abstract string Name { get; }
        public abstract int Reputation { get; set; }
        public abstract int AgeInYears { get; set; }
        public abstract int AttributePoints { get; }
        public abstract int SkillPoints { get; }
        public abstract int GeneralTalents { get; }
    }
}