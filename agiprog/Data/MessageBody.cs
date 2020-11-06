using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class MessageBody
    {
        public int MessageBodyId { get; set; }

        public string Chat { get; set; }

        public DateTime At { get; set; }

        public string User { get; set; }
    }
}
