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
            return await agiprogContext.Roadmaps.FindAsync(RoadmapId);
        }

        public  List<Roadmap> FindAllRoadmaps()
        {
            return agiprogContext.Roadmaps.ToList();
        }

        public async Task<int> AddRoadmap(Roadmap Roadmap)
        {
            agiprogContext.Roadmaps.Add(Roadmap);
            await agiprogContext.SaveChangesAsync();
            return Roadmap.RoadmapID;
        }

        public async Task RemoveRoadmap(Roadmap roadmap)
        {
            agiprogContext.Roadmaps.Remove(roadmap);
            await agiprogContext.SaveChangesAsync();
        }
    }
}
