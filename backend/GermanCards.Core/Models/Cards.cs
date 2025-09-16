using System.Formats.Tar;

namespace GermanCards.Core.Models;


public class Card
{
    public int Id { get; set; }
    public string GermanWord { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
