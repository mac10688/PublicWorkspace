using System;
using System.Windows;
using System.Windows.Input;

using MVVMDemo.Commands;
using MVVMDemo.Model;
  
namespace MVVMDemo.ViewModels
{
    class CustomerViewModel
    {
        public CustomerModel CustomerModelObject { get; set; }

        public CustomerViewModel()
        {
            //This data will load as the default Customer from the model attached to the view
            CustomerModelObject = new CustomerModel { FirstName = "Sai", LastName = "SriMahi"};
        }
        
        private CustomerDelegateCommand saveCustomerCommand;

        public ICommand SaveCustomerCommand
        {
            get
            {
                if (saveCustomerCommand == null)
                {
                    saveCustomerCommand = new CustomerDelegateCommand(new Action(SaveExecuted), new Func<bool>(SaveCanExecute), false);
                }
                return saveCustomerCommand;
            }
        }

        public bool SaveCanExecute()
        {
            if (string.IsNullOrEmpty(CustomerModelObject.FirstName) || string.IsNullOrEmpty(CustomerModelObject.LastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SaveExecuted()
        {
            MessageBox.Show(string.Format("Saved: {0} ", CustomerModelObject.FullName));
        }
    }
}