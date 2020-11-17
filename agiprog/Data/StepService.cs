using agiprog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class StepService
    {


        public async Task<Step> FindStep(int StepId, agiprogContext Context)
        {
            return await Context.Steps.FindAsync(StepId);
        }

        public List<Step> FindAllSteps( agiprogContext Context)
        {
            return Context.Steps.ToList();
        }

        public async Task<int> AddStep(Step Step, agiprogContext Context)
        {
            Context.Steps.Add(Step);
            await Context.SaveChangesAsync();
            return Step.StepId;
        }


        public async Task<int> UpdateStep(Step Step, agiprogContext Context)
        {
            Context.Update(Step);
            await Context.SaveChangesAsync();
            return Step.StepId;
            
        }

        public async Task RemoveStep(Step step, agiprogContext Context)
        {
            Context.Steps.Remove(step);
            await Context.SaveChangesAsync();

        }
    }
}
