using System.ComponentModel;

namespace PcRepaire.Models
{
    public class EqupmentUsing : Equipment
    {
        public int? EquipUserId { get; set; }
        [DisplayName("User")]
        public EquipUser EquipUser { get; set; }
        [DisplayName("Used/Free")]
        public bool Used
        {
            get
            {
                if (this.EquipUser == null)
                    return false;
                else
                    return true;
            }
        }

    }
}
