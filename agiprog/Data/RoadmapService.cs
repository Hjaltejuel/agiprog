using agiprog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class RoadmapService
    {
 

        public async Task<NewRoadmap> FindNewRoadmap(int NewRoadmapId, agiprogContext Context)
        {
            return await Context.NewRoadmaps.FindAsync(NewRoadmapId);
        }



        public  List<NewRoadmap> FindAllNewRoadmaps(agiprogContext Context)
        {

            return Context.NewRoadmaps.ToList();
        }

        public async Task<NewRoadmap> AddNewRoadmap(NewRoadmap NewRoadmap, List<Step> steps, agiprogContext Context)
        { 
            
            var r = new NewRoadmap() { Description = NewRoadmap.Description, Name = NewRoadmap.Name, Image = NewRoadmap.Image };
            Context.NewRoadmaps.Add(r);
            await Context.SaveChangesAsync();

            var rs = steps.Select(s => new RoadmapStep { StepId = s.StepId, NewRoadmapId = r.NewRoadmapId });
            Context.RoadmapSteps.AddRange(rs);
            await Context.SaveChangesAsync();
            r.RoadmapSteps = rs.ToList();
            return r;
        }


        public async Task<int> UpdateNewRoadmap(NewRoadmap NewRoadmap, List<RoadmapStep> Selected, agiprogContext Context)
        {
            Context.RoadmapSteps.RemoveRange(NewRoadmap.RoadmapSteps);
            NewRoadmap.RoadmapSteps = Selected;
            Context.Update(NewRoadmap);
            await Context.SaveChangesAsync();
            return NewRoadmap.NewRoadmapId;
        }
        
        public List<Step> FindAllNewRoadmapStepsForNewRoadmap(NewRoadmap NewRoadmap, agiprogContext Context)
        {
            return Context.RoadmapSteps.Where(r => r.NewRoadmapId == NewRoadmap.NewRoadmapId).Select(a => a.Step).ToList();
        }
        public async Task RemoveNewRoadmap(NewRoadmap roadmap, agiprogContext Context)
        {
            Context.NewRoadmaps.Remove(roadmap);
            await Context.SaveChangesAsync();
        }
    }
}
