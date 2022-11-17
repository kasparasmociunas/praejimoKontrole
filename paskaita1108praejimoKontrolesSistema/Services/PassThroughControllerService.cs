using System;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Repositories;
using paskaita1108praejimoKontrolesSistema;



namespace paskaita1108praejimoKontrolesSistema



{




    public class PassThroughControllerService   
    {

        int uniqID = 0;
        //static HumanRepository humanRepository { get; set; }
        //static EventRepository eventRepository { get; set; }



        public PassThroughControllerService()
        {
            
      
        }




        List<int> userChoices;
        bool canPass;



        public List<int> DataColector() {
            Console.WriteLine("Choose your name: ");

            HumanRepository.PrintHumanList();
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
          
            
            if (HumanRepository.humans[userChoices[0]].GateNumber == userChoices[1])
            {
                Console.WriteLine($"{HumanRepository.humans[userChoices[0]].FirstName} can pass");
                canPass = true;
                
            }
            else {
                Console.WriteLine($"{HumanRepository.humans[userChoices[0]].FirstName} is not allowed to use this entrance");
               canPass = false;
            }

           

        }

        public void EventLogger()

        {
            var timeStamp = DateTime.Now;



            var newGatesEvent = new GatesEvent();
            bool status = HumanRepository.humans[userChoices[0]].IsInside;
            newGatesEvent.EventId = uniqID;
            
            newGatesEvent.Timestamp = timeStamp;
            newGatesEvent.GateNumber = userChoices[1];
            newGatesEvent.Human = HumanRepository.humans[userChoices[0]];
            if (status)
            {
                newGatesEvent.Direction = "left";
            }
            else{ newGatesEvent.Direction = "entered"; }

            if (canPass)
            {
               
                EventRepository.AddEvent(newGatesEvent);
                uniqID++;
                if (status)
                {
                    HumanRepository.humans[userChoices[0]].IsInside = false; //keicia statusa, lauke ar viduje
                }
                else {
                    HumanRepository.humans[userChoices[0]].IsInside = true;
                }
                Console.WriteLine("***event recorded***");
              
              
            }


        }


    }
}

