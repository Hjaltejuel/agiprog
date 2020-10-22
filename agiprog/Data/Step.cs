using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class Step
    {
        public int StepId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String VideoUrl { get; set; }

        public byte[] Img { get; set; }

        public int RoadmapId{ get; set;}

        public Roadmap Roadmap { get; set; }

    }
}
