using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DataObjects.DTO
{
    public class GetParticipantsByEventDTO
    {
        private int _EventId;
        private string _SortExpression;
        private string _SortDirection;


        [DataMember(Name = "EventId")]
        public int EventId { get { return _EventId; } set { _EventId = value; } }

        [DataMember(Name = "SortExpression")]
        public string SortExpression { get { return _SortExpression; } set { _SortExpression = value; } }

        [DataMember(Name = "SortDirection")]
        public string SortDirection { get { return _SortDirection; } set { _SortDirection = value; } }

    }
}
