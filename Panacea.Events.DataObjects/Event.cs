using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DataObjects
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public DateTime EventDate { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
