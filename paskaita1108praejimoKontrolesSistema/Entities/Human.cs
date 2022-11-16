using System;
namespace paskaita1108praejimoKontrolesSistema.Entities
{
    public class Human
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GateNumber { get; set; }
        public int WorkingHours { get; set; }
        public bool IsInside { get; set; }

    }
}

