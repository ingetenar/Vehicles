using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class Boat : Vehicle, ISwimmable
    {
        public Boat(string make, string model)
            : base(make, model)
        {
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

            return $"{Make} sailed {km} km.";
        }
    }
}
