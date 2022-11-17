using System;
using System.Security.Cryptography;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Repositories;

namespace paskaita1108praejimoKontrolesSistema.Repositories
{
    public static class EventRepository
    {


        public static List<GatesEvent> eventsList = new List<GatesEvent>();

        public static void AddEvent(GatesEvent gatesEvent)
        {
            eventsList.Add(gatesEvent);
        }


        public static void ShowEvents()
        {
            Console.WriteLine("REPORT:");
            foreach (var gateEvent in eventsList)
            {
                Console.WriteLine("ID: {0}, time: {1}, full name: {2} {3}, direction: {4}", gateEvent.EventId, gateEvent.Timestamp, gateEvent.Human.FirstName, gateEvent.Human.LastName, gateEvent.Direction);
            }
            Console.WriteLine("___report end___");
        }


        public static List<GatesEvent> GetSortedEvents() {
            return eventsList.OrderBy(o => o.Human.FirstName).ToList();
             
        }



        public static void ShowSortedEvents()
        {
            Console.WriteLine("SORTED REPORT:");
            foreach (var gateEvent in GetSortedEvents())
            {
                Console.WriteLine("ID: {0}, time: {1}, full name: {2} {3}, direction: {4}", gateEvent.EventId, gateEvent.Timestamp, gateEvent.Human.FirstName, gateEvent.Human.LastName, gateEvent.Direction);
            }
            Console.WriteLine("___report end___");

        }


        public static List<GatesEvent> GetSingleEmployeeEvents(Human employee){
            List<GatesEvent> singleEmployeeEventList = new List<GatesEvent>();
            foreach(var gatesEvent in eventsList) {
                if (gatesEvent.Human.Id == employee.Id) {
                    singleEmployeeEventList.Add(gatesEvent);                   
                }
            }
            return singleEmployeeEventList;
        }

        public static void CaluculateTimeInside(Human employee) {
            List<GatesEvent> singleEmployeeEventList = GetSingleEmployeeEvents(employee);
            int i = 0;
            TimeSpan timeSpentTotal = employee.WorkingHours;
            if (singleEmployeeEventList.Count > 1 && singleEmployeeEventList.Count % 2 == 0) {
                while (i < singleEmployeeEventList.Count )
                {
                    int secondEventIndex = i + 1;
                    var timeSpent = (singleEmployeeEventList[secondEventIndex].Timestamp.Subtract(singleEmployeeEventList[i].Timestamp));
                    timeSpentTotal  = timeSpentTotal + timeSpent;
                    i = i + 2;
                }
            }
           
            
            employee.WorkingHours = timeSpentTotal;
        }

        public static void ShowIndividualTimeSpent(Human employee)
        {
            if (employee.IsInside) {
                Console.WriteLine("{0}, {1} {2} is still inside;", employee.Id,
                employee.FirstName,
                employee.LastName);
            }
            else {
                Console.WriteLine("{0}, {1} {2} worked {3} hours {4} minutes {5} seconds;",
                    employee.Id,
                    employee.FirstName,
                    employee.LastName,
                    employee.WorkingHours.Hours,
                    employee.WorkingHours.Minutes,
                    employee.WorkingHours.Seconds);
            }
            
        }

        public static void ShowWorkingHours() {
            foreach (var human in HumanRepository.humans) {
                CaluculateTimeInside(human);
                ShowIndividualTimeSpent(human);
            }
        }
    }



}


