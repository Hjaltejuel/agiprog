using agiprog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapService
    {
 

        public async Task<Roadmap> FindRoadmap(int RoadmapId, agiprogContext Context)
        {
            return await Context.Roadmaps.FindAsync(RoadmapId);
        }

        public  List<Roadmap> FindAllRoadmaps(agiprogContext Context)
        {

            return Context.Roadmaps.ToList();
        }

        public async Task<int> AddRoadmap(Roadmap Roadmap, agiprogContext Context)
        {
            Context.Roadmaps.Add(Roadmap);
            await Context.SaveChangesAsync();
            return Roadmap.RoadmapID;
        }

        public async Task RemoveRoadmap(Roadmap roadmap, agiprogContext Context)
        {
            Context.Roadmaps.Remove(roadmap);
            await Context.SaveChangesAsync();
        }
    }
}
