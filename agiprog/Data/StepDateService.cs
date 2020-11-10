using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class StepDateService
    {
        private readonly agiprogContext agiprogContext;

        public StepDateService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }

        public async Task AddStepDate(StepDate StepDate)
        {
            await agiprogContext.StepDates.AddAsync(StepDate);
        }

        public async Task<StepDate> FindStepDate(int StepId, String MeetingId)
        {
            return await agiprogContext.StepDates.FindAsync(StepId, MeetingId);
        }
    }
}
