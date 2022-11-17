using System;
using paskaita1108praejimoKontrolesSistema.Entities;
using paskaita1108praejimoKontrolesSistema.Services;
namespace paskaita1108praejimoKontrolesSistema.Repositories

{
    public static class HumanRepository
    {

        public static List<Human> humans = GetHumanList();

        public static List<Human> GetHumanList() {
            FileService fileService = new FileService();
            List<Human> humans = fileService.ReadHumanList();
            return humans;
        }



        public static void PrintHumanList()
        {
            foreach (var human in humans) {
                Console.WriteLine("ID: {0}, name: {1} {2}, is inside: {3}", human.Id, human.FirstName, human.LastName, human.IsInside);
            }
        }
    }
}

