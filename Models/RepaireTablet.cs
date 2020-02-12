namespace PcRepaire.Models
{
    public class RepaireTablet : RepaireLists
    {
        public int? TabletId { get; set; }
        public Tablet Tablet { get; set; }
    }
}
