using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{



    public class Equipment
    {
        private bool freeForUse;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Model { get; set; }
        [DisplayName("Serial number")]
        public string SerialNumber { get; set; }
        public int SoftWareId { get; set; }
        public int? EquipUserId { get; set; }
        public SoftWare SoftWare { get; set; }
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
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

