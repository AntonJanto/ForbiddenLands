using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Skills
{
    public class MoveSkill : Skill
    {
        public MoveSkill(Attribute attribute) : base(SkillOptions.Move, attribute)
        {

        }
    }
}