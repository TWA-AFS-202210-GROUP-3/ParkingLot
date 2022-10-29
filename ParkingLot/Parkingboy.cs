using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parkingboy
    {
        private Car carShouldFetch;

        public Parkingboy()
        {
        }

        public bool Fetchcar(Car car)
        {
            if (carShouldFetch == null)
            {
                throw new NotImplementedException();
            }

            carShouldFetch = car;
            return true;
        }

        public bool Parkcar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}