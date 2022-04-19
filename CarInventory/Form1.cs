using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();


        public Form1()
        {
            InitializeComponent();
             loadDB();
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

        //private void ClearLabels()
        //{
        //    yearInput.Text = "";
        //    makeInput.Text = "";
        //    colourInput.Text = "";
        //    mileageInput.Text = "";
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDB();
        }

        public void loadDB()
        {
            XmlReader reader = XmlReader.Create("Resources/CarInventory.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    int year = reader.ReadContentAsInt();
                    // OR   int year = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("make");
                    string make = reader.ReadString();

                    reader.ReadToNextSibling("colour");
                    string colour = reader.ReadString();

                    reader.ReadToNextSibling("mileage");
                    double mileage = reader.ReadElementContentAsDouble();

                    Car c = new Car(year, make, colour, mileage);
                    cars.Add(c);

                }
            }
            reader.Close();
        }

        public void SaveDB()
        {
            XmlWriter writer = XmlWriter.Create("Resources/CarInventory.xml", null);

            writer.WriteStartElement("Car");
            foreach (Car car in cars)
            {
                writer.WriteStartElement("CarObject");
                writer.WriteElementString("year", car.year.ToString());
                writer.WriteElementString("make", car.make);
                writer.WriteElementString("colour", car.colour);
                writer.WriteElementString("mileage", car.mileage.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
