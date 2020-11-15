using agiprog.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class MessageService
    {


        public async Task<Message> FindMessage(int StepId, String MeetingId, agiprogContext Context)
        {
            return await Context.Messages.SingleOrDefaultAsync(m  => m.StepId == StepId && m.MeetingId == MeetingId);
        }




        public async Task RemoveMessageBody( MessageBody Message, agiprogContext Context)
        {
            var result = await Context.MessageBodies.FindAsync(Message.MessageBodyId);
            if(result != null)
            {
                Context.MessageBodies.Remove(result);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddMessage(Message message, agiprogContext Context)
        {
            await Context.Messages.AddAsync(message);
            await Context.SaveChangesAsync();
        }


        public async Task AddMessageBody(MessageBody message, agiprogContext Context)
        {
            await Context.MessageBodies.AddAsync(message);
            await Context.SaveChangesAsync();
        }

        public async Task<int> CountBodies(String meetingId, int stepId,  agiprogContext Context)
        {
            return await Context.MessageBodies.Where(m => m.MeetingId == meetingId && m.StepId == stepId).CountAsync();
        }
        public async Task<List<MessageBody>> FindMessageBodies(String meetingId, int stepId, int start, int stop, agiprogContext Context)
        {
            return await Context.MessageBodies.Where(m => m.MeetingId == meetingId && m.StepId == stepId).OrderByDescending(m => m.At).Skip(start).Take(stop).ToListAsync();
        }

    }
}
