using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class EqupmentUsing :Equipment
    {
        private bool freeForUse;

        public int? EquipUserId { get; set; }
        [DisplayName("User")]
        public EquipUser EquipUser { get; set; }
        [DisplayName("Used/Free")]
        public string Used
        {
            get
            {
                if (this.EquipUser == null)
                    return "free";
                else
                    return "used";
            }

        }

    }
}
