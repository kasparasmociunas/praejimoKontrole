using System;
using paskaita1108praejimoKontrolesSistema.Repositories;
using paskaita1108praejimoKontrolesSistema.Services;
using paskaita1108praejimoKontrolesSistema.Entities;

namespace paskaita1108praejimoKontrolesSistema
{

    public class Menu
    {
  

        public Menu( )
        {
  
        }


        PassThroughControllerService passThroughService = new PassThroughControllerService();
        bool continueLoop = true;

       

        public void ShowMenu() {
            while (continueLoop) {
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Print Employee list");
                Console.WriteLine("2: Log event");
                Console.WriteLine("3: Show event report");
                Console.WriteLine("4: Show sorted event report");
                Console.WriteLine("5: Show working time report");

                Console.WriteLine("9: Exit");


                var userChoice = GetUserChoice();
                
                switch (userChoice){
                    case 0:
                        continue;
                    case 1:
                        HumanRepository.PrintHumanList();
                        continueLoop = true;
                        break;
                    case 2:
                        passThroughService.AccessChecker();
                        passThroughService.EventLogger();

                        continueLoop = true;
                        break;
                    case 3:
                        EventRepository.ShowEvents();
                        continueLoop = true;
                        break;
                    case 4:
                        EventRepository.ShowSortedEvents();
                        continueLoop = true;
                        break;
                    case 5:
                        EventRepository.ShowWorkingHours();
                        continueLoop = true;
                        break;
                    case 9:
                        Console.WriteLine("Goodbye!");
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

