namespace PcRepaire.Models
{
    public class RepaireTablet : RepaireList
    {
        public int? TabletId { get; set; }
        public Tablet Tablet { get; set; }
    }
}
