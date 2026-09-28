using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class AmphibiousCar : Vehicle, IDrivable, ISwimmable
    {
        public AmphibiousCar(string make, string model)
            : base(make, model)
        {
        }

        public string Drive(double km)
        {
            return Move(km);
        }

        public string Swim(double km)
        {
            return Move(km);
        }

        public override string Move(double km)
        {
            if (km <= 0)
                throw new ArgumentException("Distance must be positive.");

            Odometer += km;

            return $"{Make} moved on land or water {km} km.";
        }
    }
}
