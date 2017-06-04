using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DataObjects
{
   public class Participant
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
