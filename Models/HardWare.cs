using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class HardWare
    {
        private double speedEthernetI;
        private double speedSsdI;
        private double speedProcessorI;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [DisplayName("Type of hardware")]
        public string HardType { get; set; }

        public double SpeedEthernetI
        {
            get => speedEthernetI;
            set
            {
                if (value > 0 && value < 1)
                    speedEthernetI = value;
            }
        }
        public double SpeedSsdI
        {
            get => speedSsdI;
            set
            {
                if (value > 0 && value < 1)
                    speedSsdI = value;
            }
        }
        public double SpeedProcessorI
        {
            get => speedProcessorI;
            set
            {
                if (value > 0 && value < 1)
                    speedProcessorI = value;
            }
        }

    }

}
