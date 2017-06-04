using Panacea.Events.DAL.Utils;
using Panacea.Events.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.BLL
{
    public class ParticipantLogic
    {
        public bool AddParticipant(Participant objParticipant)
        {
            try
            {
                return DbService.AddParticipant(objParticipant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckIfParticipantExists(int eventId, string email)
        {
            try
            {
                return DbService.CheckIfParticipantExists(eventId, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Participant> GetParticipantsByEvent(int eventId, string sortExperession, string sortDirection)
        {
            try
            {
                return DbService.GetParticipantsByEvent(eventId, sortExperession, sortDirection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
