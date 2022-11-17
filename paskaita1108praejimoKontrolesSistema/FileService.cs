using System;
using paskaita1108praejimoKontrolesSistema.Entities;

namespace paskaita1108praejimoKontrolesSistema.Services
{ 
    public class FileService
    {
        


        public List<Human> ReadHumanList() {
            string humanListFilePath = "/Users/admin/Desktop/vigi .NET/paskaita1108praejimoKontrolesSistema/data files/Humans.csv";
            string fileText = File.ReadAllText(humanListFilePath);
            string[] lines = fileText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            List<Human> humans = new List<Human>();
            FileInfo fi = new FileInfo(humanListFilePath);
            if (fi.Extension == ".csv") {
                
                foreach (var line in lines) {
                    string[] humanDataArray = line.Split(',');
                    var human = new Human
                    {
                        Id = Convert.ToInt32(humanDataArray[0]),
                        FirstName = humanDataArray[1],
                        LastName = humanDataArray[2],
                        GateNumber = Convert.ToInt32(humanDataArray[3]),
                        WorkingHours = TimeSpan.Parse(humanDataArray[4]),
                        IsInside = Convert.ToBoolean(humanDataArray[5])

                    };

                    humans.Add(human);

                }
                
            }
            return humans;

        }

    }
}
