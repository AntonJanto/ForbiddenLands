using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Skills
{
    public class MeleeSkill : Skill
    {
        public MeleeSkill(Attribute attribute) : base(SkillOptions.Melee, attribute)
        {

        }
    }
}