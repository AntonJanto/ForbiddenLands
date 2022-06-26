namespace ForbiddenLands.Core.Models
{
    public class Age
    {
        public virtual string Name { get; }
        public virtual int Reputation { get; set; }
        public virtual int AgeInYears { get; set; }
        public virtual int AttributePoints { get; }
        public virtual int SkillPoints { get; }
        public virtual int GeneralTalents { get; }
    }
}