namespace ForbiddenLands.Core.Models
{
    public abstract class Attribute
    {
        public const int LIMIT = 6;
        public abstract string Name { get; set; }
        public abstract int TotalDie { get; set; }
        public abstract int CurrentDie { get; set; }
    }
}