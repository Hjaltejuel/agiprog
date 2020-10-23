using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapService
    {
        private readonly agiprogContext agiprogContext;

        public RoadmapService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }


        public async Task<Roadmap> FindRoadmap(int RoadmapId)
        {
            return await agiprogContext.roadmaps.FindAsync(RoadmapId);
        }

        public  List<Roadmap> FindAllRoadmaps()
        {
            return agiprogContext.roadmaps.ToList();
        }

        public async Task<int> AddRoadmap(Roadmap Roadmap)
        {
            agiprogContext.roadmaps.Add(Roadmap);
            await agiprogContext.SaveChangesAsync();
            return Roadmap.RoadmapID;
        }

        public void RemoveRoadmap(int RoadMapId)
        {
            var Roadmap = new Roadmap();
            Roadmap.RoadmapID = RoadMapId;
            agiprogContext.roadmaps.Attach(Roadmap);
            agiprogContext.roadmaps.Remove(Roadmap);

        }
    }
}
