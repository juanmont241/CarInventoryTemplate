using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventory
{
    internal class Car
    {
        public int year;
        public string make;
        public string colour;
        public double mileage;

        public Car (int _year, string _make, string _colour, double _mileage)
        {
            year = _year;
            make = _make;
            colour = _colour;
            mileage = _mileage;
        }
    }
}
