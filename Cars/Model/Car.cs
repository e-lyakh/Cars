using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Cars
{
    class Car : INotifyPropertyChanged
    {
        string name;
        string model;
        int year;
        string color;
        string imagePath;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Name");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public Car(string name, string model, int year, string color, string imagePath)
        {
            this.name = name;
            this.model = model;
            this.year = year;
            this.color = color;
            this.imagePath = imagePath;
        }

        //public Car() { } // Why is created a last additional item?

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }        
    }
}
