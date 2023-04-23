using HWK4.Models;
using System.Collections.Generic;

namespace HWK4.Interfaces
{
    public interface ICarRepository
    {
        // methods to manipulate the data.
        List<Car> ReadAllCarsData();

        Car GetCarName(int IndexNo);

        Car AddCarData(Car car);

        bool SaveCarData();

        Car ModifyCarData(Car editCar);

        Car RemoveCarData(int IndexNo);

        String AnalyzeCarData();

        
    }
}
