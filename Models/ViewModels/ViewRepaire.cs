using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models.ViewModels
{
    public class ViewRepaire : RepaireLists
    {
        public string SerialNumber { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }
        public string Model { get; set; }

        public ViewRepaire(RepairePC pc)
        {
            this.Id = pc.Id;
            this.DateRepaire = pc.DateRepaire;
            this.RepaireManId = pc.RepaireManId;
            this.RepaireMan = pc.RepaireMan;
            this.SerialNumber = pc.Pc.SerialNumber;
            this.Type = "Pc";
            this.Model = pc.Pc.Model;
        }

        public ViewRepaire (RepaireTablet tablet)
        {
            this.Id = tablet.Id;
            this.DateRepaire = tablet.DateRepaire;
            this.RepaireManId = tablet.RepaireManId;
            this.RepaireMan = tablet.RepaireMan;
            this.SerialNumber = tablet.Tablet.SerialNumber;
            this.Type = "Tablet";
            this.Model = tablet.Tablet.Model;
        } 
    }
}
