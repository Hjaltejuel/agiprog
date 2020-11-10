using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class MessageService
    {
        private readonly agiprogContext agiprogContext;

        public MessageService(agiprogContext agiprogContext)
        {
            this.agiprogContext = agiprogContext;
        }

        public async Task<Message> FindMessage(int StepId, String MeetingId)
        {
            return await agiprogContext.Messages.FindAsync( MeetingId, StepId);
        }


        public async Task AddMessage(Message message)
        {
            await agiprogContext.Messages.AddAsync(message);
            await agiprogContext.SaveChangesAsync();
        }

        public async Task UpdateMessage(Message message)
        {
            agiprogContext.Messages.Update(message);
            await agiprogContext.SaveChangesAsync();
        }

    }
}
