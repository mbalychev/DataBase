﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PcRepaire.Models
{
    public class SoftWare
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [DisplayName("Name software")]
        public string Name { get; set; }
    }

}
