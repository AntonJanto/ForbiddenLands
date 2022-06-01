namespace ForbiddenLands.Core.Models.Ages
{
    public class OldAge : Age
    {
        public override string Name => "Old";
        public override int Reputation { get; set; } = 2;
        public override int AgeInYears { get; set; } = 51;
        public override int AttributePoints => 13;
        public override int SkillPoints => 12;
        public override int GeneralTalents => 3;
    }
}
