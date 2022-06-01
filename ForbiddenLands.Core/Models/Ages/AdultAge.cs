namespace ForbiddenLands.Core.Models.Ages
{
    public class AdultAge : Age
    {
        public override string Name => "Adult";
        public override int Reputation { get; set; } = 1;
        public override int AgeInYears { get; set; } = 26;
        public override int AttributePoints => 14;
        public override int SkillPoints => 10;
        public override int GeneralTalents => 2;
    }
}
