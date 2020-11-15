using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data.DTO
{
    public class MeetingDTO
    {
        public Meeting Meeting { get; set; }

        public Roadmap Roadmap { get; set; }

        public List<RoadmapStep> RoadmapSteps {get;set;}

        public List<StepDate> StepDates { get; set; }
    }
}
