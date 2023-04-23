
using HW2Rest;
using HWK4.Models;
using static System.Formats.Asn1.AsnWriter;

namespace HWK4
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            List<Car> printString = new List<Car>();
            if (!dataContext.Cars.Any())
            {
                List<string> store;
                // Add data array 
                store = new List<string>();
                using (StreamReader reader = new StreamReader("Data.txt"))
                {
                    string line;
                    // Reading text from file and adding to _data object, also check null condition
                    while ((line = reader.ReadLine()) != null)
                    {
                        store.Add(line);
                    }
                }
                // Iterate through the data
                for (int i = 0; i < store.Count(); i++)
                {
                    string[] split = store[i].Split(','); //Splitting file
                    printString.Add(new Car { IndexNo = int.Parse(split[0]), CarName = split[1], Year = int.Parse(split[2]), Director = split[3], Producer = split[4], CriticScore = int.Parse(split[5]) });
                }
            };
            dataContext.Cars.AddRange(printString);
            dataContext.SaveChanges();
        }

    }
}
