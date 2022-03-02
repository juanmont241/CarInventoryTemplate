using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();


        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Car c = new Car(2012, "Ford", "White", 12300.5);
            int year = Convert.ToInt32(yearInput.Text);
            string make = makeInput.Text;
            string colour = colourInput.Text;
            double mileage = Convert.ToDouble(mileageInput.Text);

            Car c = new Car(year, make, colour, mileage);
            cars.Add(c);

            DisplayItems();

        }

        private void RemoveInput_Click(object sender, EventArgs e)


        {
            string make = makeInput.Text;

            for (int i = 0; i < cars.Count; i++)
            {
                if (make == cars[i].make) 
                { 
                     cars.RemoveAt(i);
                }
            }

            //OR

            //foreach(Car car in cars)
            //{
            //    if(make == car.make)
            //    {
            //        cars.Remove(car);
            //        break;
            //    }
            //}

           DisplayItems();
        }

        public void DisplayItems()
        {

            outputLabel.Text = "";

            foreach (Car car in cars)
            {
                outputLabel.Text += $"{car.year} {car.make} {car.colour} {car.mileage}\n";
            }
        }
    }
}
