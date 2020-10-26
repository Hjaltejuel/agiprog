﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Roadmap
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoadmapID { get; set; }
        [Required]
        public String Name { get; set; }
   

        public String Image { get; set; }
        [Required]
        public String Description { get; set; }
 
        public virtual List<RoadmapStep> RoadmapSteps { get; set; }


        public virtual List<Meeting> Meetings { get; set; }
    }
}
