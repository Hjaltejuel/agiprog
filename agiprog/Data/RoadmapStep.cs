using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapStep
    {
        public int RoadmapId { get; set; }

        public Roadmap Roadmap { get; set; }

        public int StepId { get; set; }

        public Step Step { get; set; }

    }
}
