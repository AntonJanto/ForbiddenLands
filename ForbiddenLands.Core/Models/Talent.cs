using System.Collections.Generic;

namespace ForbiddenLands.Core.Models
{
    public class Talent
    {
        public string Name { get; set; }
        public int Level { get; set; } = 0;
        public string Description { get; set; }
        public Dictionary<int, string> DescriptionPerLevel = new Dictionary<int, string>();
    }
}