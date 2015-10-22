using System.ComponentModel.DataAnnotations;

namespace AcmeMenwear.Models
{
    public class SlideImg
    {
        public int SlideImgId { get; set; }
        [StringLength(255)]
        public string SlideImgName { get; set; }
        [StringLength(100)]
        public string SlideImgContentType { get; set; }
        public byte[] SlideImgContent { get; set; }
        public FileType FileType { get; set; }
        public int SlideId { get; set; }
        public virtual Slide Slide { get; set; }
    }
}