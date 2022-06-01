using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Attributes
{
    public class EmpathyAttribute : Attribute
    {
        public override string Name { get; set; } = AttributeOptions.Empathy;
        public override int TotalDie { get; set; } = 1;
        public override int CurrentDie { get; set; } = 1;
    }
}
