﻿using System;
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
            return await agiprogContext.Meetings.FindAsync(meetingId);
        }
        public async Task UpdateMeeting(Meeting meeting)
        {
            agiprogContext.Update(meeting);
            await agiprogContext.SaveChangesAsync();
        }



        public List<Meeting> FindAllMeetings()
        {
            return agiprogContext.Meetings.ToList();
        }

        public async Task<String> AddMeeting(Meeting meeting)
        {
            agiprogContext.Meetings.Add(meeting);
            await agiprogContext.SaveChangesAsync();
            return meeting.MeetingId;
        }

        public async Task RemoveMeeting(Meeting meeting)
        {
            agiprogContext.Meetings.Remove(meeting);
            await agiprogContext.SaveChangesAsync();

        }


    }
}
