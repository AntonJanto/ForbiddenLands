namespace ForbiddenLands.Core.Models.Ages
{
    public class YoungAge : Age
    {
        public override string Name => "Young";
        public override int Reputation { get; set; } = 0;
        public override int AgeInYears { get; set; } = 16;
        public override int AttributePoints => 15;
        public override int SkillPoints => 8;
        public override int GeneralTalents => 1;
    }
}
