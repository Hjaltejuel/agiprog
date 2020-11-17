using agiprog.Areas.Identity.Data;
using agiprog.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class MeetingService
    {
  

        public async Task<Meeting> FindMeeting(String meetingId, agiprogContext Context)
        {
            return await Context.Meetings.FindAsync(meetingId);
        }
        public async Task UpdateMeeting(Meeting meeting, agiprogContext Context)
        {
            Context.Update(meeting);
            await Context.SaveChangesAsync();
        }



        public List<Meeting> FindAllMeetings(agiprogContext Context)
        {
            return Context.Meetings.ToList();
        }

        public async Task<Meeting> AddMeeting(Meeting meeting, List<StepDate> stepDates, agiprogContext Context)
        {

            var r = new Meeting() { Name = meeting.Name, NewRoadmapId = meeting.NewRoadmapId  };
            Context.Meetings.Add(r);
            await Context.SaveChangesAsync();

            var rs = stepDates.Select(step => new StepDate() { MeetingId = r.MeetingId, StepId = step.StepId, Step = null, Date = step.Date });
            Context.StepDates.AddRange(rs);
            await Context.SaveChangesAsync();
            r.StepDates = rs.ToList();
            return r;

        }

        public async Task<String> UpdateMeeting(Meeting Meeting, List<StepDate> stepDates, agiprogContext Context)
        {
            var stepDatesEx = await Context.StepDates.Where(s => s.MeetingId.Equals(Meeting.MeetingId)).ToListAsync();
            Context.StepDates.RemoveRange(stepDatesEx);
            Meeting.StepDates = stepDates;
            Context.Update(Meeting);
            await Context.SaveChangesAsync();
            return Meeting.MeetingId;
        }

        public async Task RemoveMeeting(Meeting meeting, agiprogContext Context)
        {
            Context.Meetings.Remove(meeting);
            await Context.SaveChangesAsync();

        }


    }
}
