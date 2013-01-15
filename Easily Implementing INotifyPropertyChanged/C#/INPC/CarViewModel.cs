using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using WPFBP;

namespace INPC
{
    //A fictional view-model class to exemplify how to use the INPC static class.
    //Ideally, there's a Car class somewhere in the business tier and the ViewModel
    //class is added on top to satisfy the MVVM model.  I'll just merge the two
    //here for brevity.
    public class CarViewModel : INotifyPropertyChanged
    {
        #region Member Data
        private string m_model;
        private int m_year;
        private string m_make;
        private ICommand m_changeCarValuesCommand;
        private bool m_modelChanged;
        private bool m_makeChanged;
        private bool m_yearChanged;
        #endregion

        #region Private Data
        //A list of values to trigger PropertyChanged.
        private List<dynamic> _cars = new List<dynamic>() {
            new {Make="Mazda", Model = "CX-7", Year=2011},
            new {Make="Mitsubishi", Model = "Lancer", Year=2010},
            new {Make="Mitsubishi", Model = "Lancer", Year=2012},
            new {Make="Hyundai", Model = "Tucson", Year=2012},
            new {Make="Hyundai", Model = "Elantra", Year=2008},
            new {Make="Porsche", Model = "Cayenne", Year=2005},
            new {Make="Ferrari", Model = "F40", Year=1992},
            new {Make="Ferrari", Model = String.Empty, Year=1992},
            new {Make="Mitsubishi", Model = "Eclipse", Year=2007}
        };
        //Current car index.
        private int _curCar = 0;
        #endregion
				
        #region Constructors
        public CarViewModel()
        {
            SetCar(_curCar);
            m_changeCarValuesCommand = new RelayCommand(new Action(SetNewCar));
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
        #region Properties
        //The following 3 properties are used to verify that the PropertyChanged event of the
        //corresponding property doesn't fire unnecessarily (when the values are the same).
        public bool ModelChanged
        {
            get
            {
                return m_modelChanged;
            }
            set
            {
                PropertyChanged.SetAndRaise(value, ref m_modelChanged, "ModelChanged", this);
            }
        }
        public bool MakeChanged
        {
            get
            {
                return m_makeChanged;
            }
            set
            {
                PropertyChanged.SetAndRaise(value, ref m_makeChanged, "MakeChanged", this);
            }
        }
        public bool YearChanged
        {
            get
            {
                return m_yearChanged;
            }
            set
            {
                PropertyChanged.SetAndRaise(value, ref m_yearChanged, "YearChanged", this);
            }
        }
        //The properties of the ficticious Car business object model.
        public string Model
        {
            get
            {
                return m_model;
            }
            set
            {
                ModelChanged = PropertyChanged.SetAndRaise(value, ref m_model, "Model", this);
            }
        }
        public string Make
        {
            get
            {
                return m_make;
            }
            set
            {
                MakeChanged = PropertyChanged.SetAndRaise(value, ref m_make, "Make", this);
            }
        }
        public int Year
        {
            get
            {
                return m_year;
            }
            set
            {
                YearChanged = PropertyChanged.SetAndRaise(value, ref m_year, "Year", this);
            }
        }
        #endregion

        #region Methods
        //These methods support the ICommand for changing the property values.
        private void SetCar(int carIndex)
        {
            dynamic c = _cars[carIndex];
            Make = String.IsNullOrWhiteSpace(c.Make) ? null : c.Make;
            Model = String.IsNullOrWhiteSpace(c.Model) ? null : c.Model;
            Year = c.Year;
        }
        private void SetNewCar()
        {
            _curCar = (_curCar + 1) % _cars.Count;
            SetCar(_curCar);
        }
        #endregion

        #region Commands
        //An ICommand object to data bind to in order to change the car values
        //on demand from the WPF user interface.
        public ICommand ChangeCarValuesCommand
        {
            get
            {
                return m_changeCarValuesCommand;
            }
        }
        #endregion
    }
}
