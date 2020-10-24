using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String MeetingId { get; set; }

        [Required]
        public String Name { get; set; }

        public Roadmap RoadMap { get; set; }

        public int CompletedSteps { get; set; }


    }
}
