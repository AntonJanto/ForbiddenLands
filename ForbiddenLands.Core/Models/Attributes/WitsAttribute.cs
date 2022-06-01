using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Attributes
{
    public class WitsAttribute : Attribute
    {
        public override string Name { get; set; } = AttributeOptions.Wits;
        public override int TotalDie { get; set; } = 1;
        public override int CurrentDie { get; set; } = 1;
    }
}
