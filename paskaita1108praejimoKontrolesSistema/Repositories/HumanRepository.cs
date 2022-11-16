using System;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Services;
namespace paskaita1108praejimoKontrolesSistema.Repositories

{
    public class HumanRepository
    {

        public  List<Human> humans = new List<Human>();

        public List<Human> GetHumanList() {
            FileService fileService = new FileService();
            List<Human> humans = fileService.ReadHumanList();
            return humans;
        }



        public void PrintHumanList()
        {
            FileService fileService = new FileService();
            List<Human> humanList = fileService.ReadHumanList();
            foreach (var human in humanList) {
                Console.WriteLine("ID: {0}, name: {1} {2}, is inside: {3}", human.Id, human.FirstName, human.LastName, human.IsInside);
            }
        }
    }
}

