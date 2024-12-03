using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppSample.Utility
{
    public abstract class CommandBase : ObservableObject, ICommand
    {
        #region 

        [ObservableProperty]
        private string label;

        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled;
            set 
            {
                if(SetProperty(ref _isEnabled, value))
                {
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        #endregion

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
        }

        public void Execute(object parameter)
        {
        }
    }
}
