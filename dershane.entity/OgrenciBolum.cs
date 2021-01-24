namespace dershane.entity
{
    public class OgrenciBolum
    {
        public int BolumId { get; set; }
        public Bolum Bolum { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
}