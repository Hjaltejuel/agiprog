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

        public async Task<String> AddMeeting(Meeting meeting, agiprogContext Context)
        {
            Context.Meetings.Add(meeting);
            await Context.SaveChangesAsync();
            return meeting.MeetingId;
        }

        public async Task RemoveMeeting(Meeting meeting, agiprogContext Context)
        {
            Context.Meetings.Remove(meeting);
            await Context.SaveChangesAsync();

        }


    }
}
