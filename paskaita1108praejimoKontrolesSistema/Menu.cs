using System;
using paskaita1108praejimoKontrolesSistema.Repositories;
using paskaita1108praejimoKontrolesSistema.Services;
using paskaita1108praejimoKontrolesSistema.Entities;

namespace paskaita1108praejimoKontrolesSistema
{

    public class Menu
    {
        static HumanRepository humanRepository1 { get; set; }
        static EventRepository eventRepository1 { get; set; }

        public Menu(HumanRepository humanRepository, EventRepository eventRepository) {
            humanRepository1 = humanRepository;
            eventRepository1 = eventRepository;
        }


        PassThroughControllerService passThroughService = new PassThroughControllerService(humanRepository1,eventRepository1);
        bool continueLoop = true;
        public void ShowMenu() {
            while (continueLoop) {
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Print Employee list");
                Console.WriteLine("2: Log event");

                var userChoice = GetUserChoice();
                
                switch (userChoice){
                    case 0:
                        continue;
                    case 1:
                        humanRepository1.PrintHumanList();
                        continueLoop = false;
                        break;
                    case 2:
                        Console.WriteLine("pasirinko 2");
                        
                        passThroughService.AccessChecker();
                        passThroughService.EventLogger();

                        continueLoop = false;
                        break;
                   
                    default :
                        break;

                }
            }
            
        }
        public int GetUserChoice()
        {
            bool isSuccess = Int32.TryParse(Console.ReadLine(), out int result);
            if (isSuccess)
            {
                return result;
            }
            Console.WriteLine("Option not available");
            return 0;
        }

    }
    
}

