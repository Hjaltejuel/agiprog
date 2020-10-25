using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapStepService
    {
        private readonly agiprogContext agiprogContext;

        public RoadmapStepService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }

        public async Task AddRoadmapSteps(List<RoadmapStep> RoadmapSteps)
        {
            RoadmapSteps.ForEach(RoadmapStep =>
            {
                if(RoadmapStep.Step.RoadmapSteps == null)
                {
                    RoadmapStep.Step.RoadmapSteps = new List<RoadmapStep>();
                }
                if(RoadmapStep.Roadmap.RoadmapSteps == null)
                {
                    RoadmapStep.Roadmap.RoadmapSteps = new List<RoadmapStep>();
                }
                RoadmapStep.Step.RoadmapSteps.Add(RoadmapStep);
                RoadmapStep.Roadmap.RoadmapSteps.Add(RoadmapStep);
                
            });
            await agiprogContext.RoadmapSteps.AddRangeAsync(RoadmapSteps);
           
        }

    }
}
