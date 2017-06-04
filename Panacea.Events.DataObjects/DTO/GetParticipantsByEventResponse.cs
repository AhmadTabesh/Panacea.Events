using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DataObjects.DTO
{
    public class GetParticipantsByEventResponse
    {
        private List<Participant> _Data;

        [DataMember(Name = "Data")]
        public List<Participant> Data { get { return _Data; } set { _Data = value; } }
    }
}
