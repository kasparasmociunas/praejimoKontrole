using System;
using paskaita1108praejimoKontrolesSistema.Entities;

namespace paskaita1108praejimoKontrolesSistema.Repositories
{
    public class EventRepository
    {


        public List<GatesEvent> eventsList = new List<GatesEvent>();

        public void AddEvent(GatesEvent gatesEvent) {
            eventsList.Add(gatesEvent);
        }
    }


}

