using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProject;

public class Parkinglot
{
    private IList<Car> cars;
    public string ParkingLotNo { get; }
    public int ParkinglotTotal { get; }
    public IList<int> ParkinglotNo { get; }
    public string ID { get; }

    //public Parkinglot()
    //{
    //    cars = new List<Car>();
    //}

    public bool Remove(Car car)
    {
        if (cars.Any(_ => _.ID == car.ID))
        {
            cars.Remove(car);
            return true;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public bool Add(Car car)
    {
        cars.Add(car);
        return false;
    }
}