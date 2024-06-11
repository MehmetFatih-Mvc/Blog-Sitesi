using neproje.Veri;
using System.ComponentModel.DataAnnotations;

namespace neproje.Models
{
    public class AnaViewModel
    {
        public List<About> Abouts { get; set; }=new();
        public List<Facts> Factss { get; set; }=new();
         public List<Progres> Progres { get; set; }=new();
         public List<Galeri> Galeri { get; set; }=new();
        public List<Content> Contents { get; set; }=new();




       
    }
}