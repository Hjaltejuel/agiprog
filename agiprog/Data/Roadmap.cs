using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Roadmap
    {
        public int RoadmapID { get; set; }

        public String name { get; set; }

        public List<Step> Steps { get; set; }

        public String? MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
