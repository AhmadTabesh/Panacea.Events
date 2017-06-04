using Panacea.Events.DAL.Model;
using Panacea.Events.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DAL.Utils
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<PanaceaEventsModel>
    {

        protected override void Seed(PanaceaEventsModel ctx)
        {

            ctx.Events.Add(new Event() { Name = "Event 1", Country = "UK", City = "London", EventDate = new DateTime(2017, 07, 01), StartTime = new DateTime(2017, 07, 01, 22, 0, 0).Ticks, EndTime = new DateTime(2017, 07, 01, 23, 59, 59).Ticks });

            ctx.Events.Add(new Event() { Name = "Event 2", Country = "Lebanon", City = "Beirut", EventDate = new DateTime(2017, 08, 01), StartTime = new DateTime(2017, 08, 01, 22, 0, 0).Ticks, EndTime = new DateTime(2017, 08, 01, 23, 59, 59).Ticks });

            ctx.Events.Add(new Event() { Name = "Event 3", Country = "UK", City = "Manchester", EventDate = new DateTime(2017, 09, 01), StartTime = new DateTime(2017, 09, 01, 22, 0, 0).Ticks, EndTime = new DateTime(2017, 09, 01, 23, 59, 59).Ticks });

            base.Seed(ctx);
        }
    }
}
