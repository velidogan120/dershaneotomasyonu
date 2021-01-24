using System.Collections.Generic;

namespace dershane.entity
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
       
        public string Name { get; set; }
        public string Url { get; set; }
        
        public int? Sınıf { get; set; }
        public string Description { get; set; }
        
        public string  ImageUrl { get; set; }
        public bool IsApproved{get; set;}
        public bool IsHome{get; set;}
        public List<OgrenciBolum> OgrenciBolumler { get; set; }
        
    }
}