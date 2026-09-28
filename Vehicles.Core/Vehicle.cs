using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Make { get; }
        public string Model { get; }

        public double Odometer { get; protected set; }

        protected Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public virtual string Move(double km)
        {
            if (km <= 0)
                throw new ArgumentException("Distance must be positive.");

            Odometer += km;

            return $"{Make} {Model} moved {km} km.";
        }

        public override string ToString()
        {
            return $"{Make} {Model}";
        }
    }
}
