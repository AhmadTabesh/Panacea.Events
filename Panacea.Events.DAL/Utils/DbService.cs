using Panacea.Events.DAL.Model;
using Panacea.Events.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DAL.Utils
{
    public class DbService
    {
        #region Events

        public static bool AddEvent(Event objEvent)
        {
            try
            {
                bool recordAdded = false;
                using (var db = new PanaceaEventsModel())
                {
                    db.Events.Add(objEvent);
                    db.SaveChanges();
                    recordAdded = true;
                }
                return recordAdded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Event> GetEvents()
        {
            try
            {
                List<Event> lstEvents = new List<Event>();
                using (var db = new PanaceaEventsModel())
                {
                    lstEvents = db.Events.OrderBy(e => e.Name).ToList();
                }
                return lstEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Participants

        public static bool AddParticipant(Participant objParticipant)
        {
            try
            {
                bool recordAdded = false;
                using (var db = new PanaceaEventsModel())
                {
                    db.Participants.Add(objParticipant);
                    db.SaveChanges();
                    recordAdded = true;
                }
                return recordAdded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckIfParticipantExists(int eventId, string email)
        {
            try
            {
                bool exists = false;
                using (var db = new PanaceaEventsModel())
                {
                    var objParticipant = db.Participants.Where(p => p.EventId == eventId && p.Email.Trim().ToLower() == email.Trim().ToLower()).FirstOrDefault();

                    exists = (objParticipant != null);
                }
                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Participant> GetParticipantsByEvent(int eventId, string sortExperession, string sortDirection)
        {
            try
            {
                List<Participant> lstParticipants = new List<Participant>();
                using (var db = new PanaceaEventsModel())
                {
                    lstParticipants = db.Participants.Where(p => p.EventId == eventId).ToList();
                    if (lstParticipants != null && !string.IsNullOrEmpty(sortExperession) && !string.IsNullOrEmpty(sortDirection))
                    {
                        if (sortDirection.ToLower() == "descending")
                            lstParticipants = lstParticipants.OrderByDescending(o => o.GetType().GetProperty(sortExperession).GetValue(o, null)).ToList();
                        else
                            lstParticipants = lstParticipants.OrderBy(o => o.GetType().GetProperty(sortExperession).GetValue(o, null)).ToList();
                    }
                }
                return lstParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
