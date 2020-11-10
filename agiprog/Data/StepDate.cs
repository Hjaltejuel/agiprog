using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class StepDate
    {
        public int StepId { get; set; }

        public virtual Step Step { get; set; }

        public String MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; }

        public DateTime Date { get; set; }
    }
}
