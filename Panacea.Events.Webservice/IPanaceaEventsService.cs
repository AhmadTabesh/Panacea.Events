using Panacea.Events.DataObjects;
using Panacea.Events.DataObjects.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Panacea.Events.Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPanaceaEventsService" in both code and config file together.

    [ServiceContract]
    public interface IPanaceaEventsService
    {


        #region Events

        [WebInvoke(UriTemplate = "/GetEvents",
        Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream GetEvents();

        #endregion

        #region Participants

        [WebInvoke(UriTemplate = "/AddParticipant",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream AddParticipant(AddParticipantDTO addParticipantDTO);

        [WebInvoke(UriTemplate = "/GetParticipantsByEvent",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream GetParticipantsByEvent(GetParticipantsByEventDTO getParticipantsByEventDTO);

        #endregion
    }
}
