using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class MeetingService
    {
        private readonly agiprogContext agiprogContext;

        public MeetingService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }


        public async Task<Meeting> FindMeeting(String meetingId)
        {
            return await agiprogContext.meetings.FindAsync(meetingId);
        }

        public async Task<String> AddMeeting(Meeting meeting)
        {
            agiprogContext.meetings.Add(meeting);
            await agiprogContext.SaveChangesAsync();
            return meeting.MeetingId;
        }

        public void RemoveMeeting(String meetingId)
        {
            var meeting = new Meeting();
            meeting.MeetingId = meetingId;
            agiprogContext.meetings.Attach(meeting);
            agiprogContext.meetings.Remove(meeting);

        }


    }
}
