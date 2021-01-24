using System.Collections.Generic;

namespace dershane.entity
{
    public class Bolum
    {
        public int BolumId { get; set; }
        public string Name {get; set;}
        public string Url {get; set;}
        public List<OgrenciBolum> OgrenciBolumler { get; set; }
    }
}