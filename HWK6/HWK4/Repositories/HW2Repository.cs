using HWK4.Interfaces;
using HWK4.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace HW2Rest
{
    public class HW2Repository : ICarRepository
    {
        private DataContext _context;

        public HW2Repository(DataContext context)
        {
            _context = context;
        }



        /// <summary>
        /// To read and fetch all the car data from the DB.
        /// </summary>
        /// <returns>database</returns>

        public List<Car> ReadAllCarsData()
        {
            return _context.Cars.ToList();
        }



        /// <summary>
        /// To specifically return an individual Car based on it's index
        /// </summary>
        /// <param name="IndexNo"></param>
        /// <returns>return the sepecifies</returns>
        public Car GetCarName(int IndexNo)
        
        {
            return _context.Cars.Where(Car => Car.IndexNo == IndexNo).FirstOrDefault();
        }



        /// <summary>
        /// To add new Car info to the Database.
        /// </summary>
        /// <param name="car"></param>
        /// <returns>rows</returns>
        public Car AddCarData(Car car)
        
        {
            _context.Cars.Add(car);
            SaveCarData();
            return car;
        }



        /// <summary>
        /// To Save the newly added, edited or removed data as finalized data into the DB.
        /// </summary>
        public bool SaveCarData()
        {
            _context.SaveChanges();
            return true;
        }



        /// <summary>
        /// To modify a specific Car Data in the DB.
        /// </summary>
        /// <param name="editCar"></param>
        /// <returns>Car</returns>
        public Car ModifyCarData(Car editCar)
        
        {
            _context.Cars.Update(editCar);
            SaveCarData();
            return editCar;
        }



        /// <summary>
        /// To remove the required Car data from the DB.
        /// </summary>
        /// <param name="IndexNo"></param>
        /// <returns>remove</returns>
        public Car RemoveCarData(int IndexNo)
        
        {
            Car deleteCar = _context.Cars.Where(car => car.IndexNo == IndexNo).SingleOrDefault();
            _context.Remove(deleteCar);
            SaveCarData();
            return deleteCar;
        }



        /// <summary>
        /// To analyze the acquired car data and provide insights.
        /// </summary>
        /// <returns>avg</returns>
        public String AnalyzeCarData()
        
        {
                /// Declaring local variables
                int carPriceTotal = 0;
                int carCount = 0;

                List<Car> carData = new List<Car>();
                carData = _context.Cars.ToList();
                 foreach (Car myCar in carData)
                {
                    if (myCar.ReleaseYear === DateTime.Now.Year.ToString();) // checking for the highest critic score
                    {
                        int carPrice = myCar.CarPrice; ///Car Price
                        carPriceTotal = carPriceTotal + carPrice;
                        carCount++;
                    
                    }
                }
                return "Average Car Price This Year Is " + (carPriceTotal / carCount);
        }
        
    }

}