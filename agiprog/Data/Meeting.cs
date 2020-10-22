using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Meeting
    {

        public String MeetingId { get; set; }

        public Roadmap RoadMap { get; set; }


        public int completedSteps { get; set; }


    }
}
