using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Cars
{
    class AppViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; }

        public DataGrid DG { get; set; }

        private Car selectedCar;        
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {                        
                        AddNew addNew = new AddNew();
                        addNew.okButton.IsDefault = true;
                        addNew.cancelButton.IsCancel = true;

                        if (addNew.ShowDialog() == true)
                        {
                            string name = addNew.tbName.Text;
                            string model = addNew.tbModel.Text;
                            int year = Convert.ToInt32(addNew.tbYear.Text);
                            string color = addNew.tbColor.Text;
                            string imagePath = addNew.tbImagePath.Text;
                            Cars.Add(new Car(name, model, year, color, imagePath));
                            selectedCar = Cars.Last();
                            DG.SelectedItem = selectedCar;                           
                        }
                    }));
            }
        }

        private RelayCommand delCommand;
        public RelayCommand DelCommand
        {
            get
            {
                return delCommand ??
                    (delCommand = new RelayCommand(obj =>
                    {
                        int selected = Cars.IndexOf(selectedCar);
                        if (selected != -1)
                        {                            
                            Cars.RemoveAt(selected);
                            if (Cars.Count > 0)
                            {
                                selectedCar = Cars.First();
                                DG.SelectedIndex = 0;                                
                            }                                
                        }
                    },
                    (obj)=> Cars.Count>0));
            }
        }

        public AppViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                new Car("Запорожец (горбатый)", "ЗАЗ-965", 1967, "снежная королева", "../Images/zaz-965.jpg"),
                new Car("Победа", "ГАЗ-М20", 1947, "айсберг", "../Images/gaz-m20.jpg"),
                new Car("Волынь", "ЛУАЗ-969", 1988, "опал", "../Images/luaz-969.jpg"),
                new Car("Чайка", "ГАЗ-14", 1980, "авантюрин", "../Images/gaz-14.jpg"),
                new Car("Лада (седан)", "ВАЗ-2107", 2015, "баклажан", "../Images/vaz-2107b.jpg")
            };
            selectedCar = Cars.First();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}