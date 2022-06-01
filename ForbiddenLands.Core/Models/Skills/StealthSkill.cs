using ForbiddenLands.Core.Models.Options;   

namespace ForbiddenLands.Core.Models.Skills
{
    public class StealthSkill : Skill
    {
        public StealthSkill(Attribute attribute) : base(SkillOptions.Stealth, attribute)
        {

        }
    }
}