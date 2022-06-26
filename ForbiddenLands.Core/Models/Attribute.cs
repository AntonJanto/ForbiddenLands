namespace ForbiddenLands.Core.Models
{
    public class Attribute
    {
        public const int LIMIT = 6;
        public virtual string Name { get; set; }
        public virtual int TotalDie { get; set; }
        public virtual int CurrentDie { get; set; }
    }
}