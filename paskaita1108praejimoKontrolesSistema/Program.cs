// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using paskaita1108praejimoKontrolesSistema;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Services;
using paskaita1108praejimoKontrolesSistema.Repositories;

namespace paskaita1108praejimoKontrolesSistema {
    public class Program {
        public static void Main() {
            HumanRepository humanRepository = new HumanRepository();
            EventRepository eventRepository = new EventRepository();




            List<Gate> gateList = new List<Gate>() {
    new Gate{GateId = 1},
    new Gate{GateId = 2},
    new Gate{GateId = 3},
    new Gate{GateId = 4},
};


            List<GatesEvent> gatesEventList = new List<GatesEvent>();

            var menu = new Menu(humanRepository, eventRepository);
            menu.ShowMenu();




            Console.ReadLine();
            Console.ReadLine();
        }
    }
}

 