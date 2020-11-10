using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Step
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepId { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Description { get; set; }

        public String? VideoUrl { get; set; }

        public String? Img { get; set; }

        public virtual List<Message> Messages { get; set; }
        public virtual List<RoadmapStep> RoadmapSteps { get; set; }

        public virtual List<StepDate> StepDates { get; set; }
    }
}
