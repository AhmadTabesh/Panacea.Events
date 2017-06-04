using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Panacea.Events.DataObjects.DTO
{
    [DataContract]
    public class AddParticipantDTO
    {
        private int _Id;
        private int _EventId;
        private string _Email;
        private string _FirstName;
        private string _Country;
        private DateTime _ArrivalDate;
        private DateTime _RegistrationDate;

        [DataMember(Name = "Id")]
        public int Id { get { return _Id; } set { _Id = value; } }

        [DataMember(Name = "EventId")]
        public int EventId { get { return _EventId; } set { _EventId = value; } }

        [DataMember(Name = "Email")]
        public string Email { get { return _Email; } set { _Email = value; } }

        [DataMember(Name = "FirstName")]
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

        [DataMember(Name = "Country")]
        public string Country { get { return _Country; } set { _Country = value; } }

        [DataMember(Name = "ArrivalDate")]
        public DateTime ArrivalDate { get { return _ArrivalDate; } set { _ArrivalDate = value; } }

        [DataMember(Name = "RegistrationDate")]
        public DateTime RegistrationDate { get { return _RegistrationDate; } set { _RegistrationDate = value; } }
    }
}
