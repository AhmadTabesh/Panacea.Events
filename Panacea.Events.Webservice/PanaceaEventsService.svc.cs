using Panacea.Events.BLL;
using Panacea.Events.DataObjects;
using Panacea.Events.DataObjects.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace Panacea.Events.Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PanaceaEventsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PanaceaEventsService.svc or PanaceaEventsService.svc.cs at the Solution Explorer and start debugging.
    public class PanaceaEventsService : IPanaceaEventsService
    {

        #region Events

        public Stream GetEvents()
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                List<Event> lstEvents = new EventLogic().GetEvents();
                if (lstEvents == null)
                    lstEvents = new List<Event>();

                var objResponse = new
                {
                    Data = lstEvents
                };
                return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objResponse)));
            }
            catch (Exception ex)
            {
                var objError = new { ErrorCode = "ServiceInternalError", ErrorDescription = ex.Message + ex.StackTrace };
                return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objError)));
            }
        }

        #endregion

        #region Participants

        public Stream AddParticipant(AddParticipantDTO addParticipantDTO)
        {
            ParticipantLogic participantLogic = new ParticipantLogic();

            var serializer = new JavaScriptSerializer();
            try
            {
                Participant objParticipant = new Participant();
                objParticipant.Email = addParticipantDTO.Email;
                objParticipant.FirstName = addParticipantDTO.FirstName;
                objParticipant.Country = addParticipantDTO.Country;
                objParticipant.ArrivalDate = addParticipantDTO.ArrivalDate;
                objParticipant.RegistrationDate = addParticipantDTO.RegistrationDate;
                objParticipant.EventId = addParticipantDTO.EventId;


                if (participantLogic.CheckIfParticipantExists(objParticipant.EventId, objParticipant.Email))
                {
                    var objError = new { ErrorCode = "ParticipantExists", ErrorDescription = "This email is already registered to the selected event." };
                    return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objError)));
                }

                bool result = participantLogic.AddParticipant(objParticipant);
                if (result == true)
                {
                    var objResponse = new
                    {

                    };
                    return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objResponse)));
                }
                else
                {
                    var objError = new { ErrorCode = "UnknownError", ErrorDescription = "An unknown error occurred, participant was not added." };
                    return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objError)));
                }
            }
            catch (Exception ex)
            {
                var objError = new { ErrorCode = "ServiceInternalError", ErrorDescription = ex.Message + ex.StackTrace };
                return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objError)));
            }
        }

        public Stream GetParticipantsByEvent(GetParticipantsByEventDTO getParticipantsByEventDTO)
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                List<Participant> lstParticipants = new List<Participant>();
                lstParticipants = new ParticipantLogic().GetParticipantsByEvent(getParticipantsByEventDTO.EventId, getParticipantsByEventDTO.SortExpression, getParticipantsByEventDTO.SortDirection);
                if (lstParticipants == null)
                    lstParticipants = new List<Participant>();

                var objResponse = new
                {
                    Data = lstParticipants
                };
                return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objResponse)));
            }
            catch (Exception ex)
            {
                var objError = new { ErrorCode = "ServiceInternalError", ErrorDescription = ex.Message + ex.StackTrace };
                return new MemoryStream(Encoding.UTF8.GetBytes(serializer.Serialize(objError)));
            }
        }

        #endregion

    }
}
