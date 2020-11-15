using agiprog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class StepDateService
    {


        public async Task AddStepDate(StepDate StepDate, agiprogContext Context)
        {
            await Context.StepDates.AddAsync(StepDate);
        }

        public async Task<StepDate> FindStepDate(int StepId, String MeetingId, agiprogContext Context)
        {
            return await Context.StepDates.FindAsync(StepId, MeetingId);
        }
    }
}
