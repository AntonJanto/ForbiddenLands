using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Bonus { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public RangeOptions Range { get; set; } = RangeOptions.Shoulder;
        public string Note { get; set; } = string.Empty;
    }
}