using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class StepService
    {

        private readonly agiprogContext agiprogContext;

        public StepService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }


        public async Task<Step> FindStep(int StepId)
        {
            return await agiprogContext.steps.FindAsync(StepId);
        }

        public List<Step> FindAllSteps()
        {
            return agiprogContext.steps.ToList();
        }

        public async Task<int> AddStep(Step Step)
        {
            agiprogContext.steps.Add(Step);
            await agiprogContext.SaveChangesAsync();
            return Step.StepId;
        }

        public async Task RemoveStep(Step step)
        {
            agiprogContext.steps.Remove(step);
            await agiprogContext.SaveChangesAsync();

        }
    }
}
