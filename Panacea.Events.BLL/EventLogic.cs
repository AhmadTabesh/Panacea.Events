using Panacea.Events.DAL.Utils;
using Panacea.Events.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.BLL
{
    public class EventLogic
    {
        public List<Event> GetEvents()
        {
            try
            {
                return DbService.GetEvents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
