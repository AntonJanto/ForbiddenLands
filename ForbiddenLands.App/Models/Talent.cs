namespace ForbiddenLands.App.Models;

public class Talent
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int MyLevel { get; set; } = 0;
    public string FullDescription { get; set; }
}
