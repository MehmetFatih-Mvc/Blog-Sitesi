using System.ComponentModel.DataAnnotations;

namespace neproje.Veri
{
    public class About
    {
    public int AboutId { get; set; }
    public string? Resim { get; set; }
    public DateTime Birthday { get; set; }
    public string? Website { get; set; }
 
    public string? Phone { get; set; }
    public string? City { get; set; }
    public int Age { get; set; }
    public string? Degree { get; set; }
    [EmailAddress]
    public string? PhEmailone { get; set; }
    public string? Açıklamabir { get; set; }
    public string? Açıklamaiki { get; set; }
    public string? Açıklamaüç { get; set; }

                                         
    }
}