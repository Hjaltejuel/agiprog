using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Message
    {

        public int StepId { get; set; }

        public virtual Step Step { get; set; }

        public String MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; }

        public virtual List<MessageBody> MessageBodies { get; set; }



    }
}
