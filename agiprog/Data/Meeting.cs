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

        public int? NewRoadmapId { get; set; }

        public virtual NewRoadmap Roadmap { get; set; }

        public int CompletedSteps { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<StepDate> StepDates { get; set; }




    }
}
