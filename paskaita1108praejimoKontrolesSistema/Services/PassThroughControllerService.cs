using System;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Repositories;
using paskaita1108praejimoKontrolesSistema;



namespace paskaita1108praejimoKontrolesSistema



{



   
    public class PassThroughControllerService   
    {

        int uniqID = 0;
        static HumanRepository humanRepository { get; set; }
        static EventRepository eventRepository { get; set; }

        public PassThroughControllerService(HumanRepository humanRepository1, EventRepository eventRepository1)
        {
            humanRepository = humanRepository1;
            eventRepository = eventRepository1;
        }



        Menu menu = new Menu(humanRepository,eventRepository);

        List<int> userChoices;
        bool canPass;




        public List<int> DataColector() {
            Console.WriteLine("Choose your name: ");

            humanRepository.PrintHumanList();
            var employeeNumber = Convert.ToInt32(Console.ReadLine());
            employeeNumber = employeeNumber - 1;
            Console.WriteLine("Choose gates (1-4): ");
            var gatesChosen = Convert.ToInt32(Console.ReadLine());
              userChoices = new List<int>() { employeeNumber,gatesChosen } ;
            return userChoices;

        }

        public void AccessChecker()
        {
            List<int> userChoices = DataColector();
            var humanList = humanRepository.GetHumanList();
            
            if (humanList[userChoices[0]].GateNumber == userChoices[1])
            {
                Console.WriteLine($"{humanList[userChoices[0]].FirstName} can pass");
                canPass = true;
                
            }
            else {
                Console.WriteLine($"{humanList[userChoices[0]].FirstName} is not allowed to use this entrance");
               canPass = false;
            }

           

        }

        public void EventLogger()

        {
            Console.WriteLine("atidarytas event logger");
            var humanList = humanRepository.GetHumanList();
            var timeStamp = DateTime.Now;



            var newGatesEvent = new GatesEvent();
            newGatesEvent.EventId = uniqID;
            
            newGatesEvent.timestamp = timeStamp;
            newGatesEvent.GateNumber = userChoices[1];
            newGatesEvent.Human = humanList[userChoices[0]];

            if (canPass)
            {
                eventRepository.AddEvent(newGatesEvent);
                uniqID++;
                Console.WriteLine("event pridetas");

                menu.ShowMenu();
                
              
            }
            if (!canPass) {
                Console.WriteLine("Event logger nieko neprides");
            }

        }


    }
}

