using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapStep
    {
        public int NewRoadmapId { get; set; }

        public virtual NewRoadmap NewRoadmap { get; set; }

        public int StepId { get; set; }

        public virtual Step Step { get; set; }

    }
}
