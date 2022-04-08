using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using AppList.Models;

namespace AppList.ViewModels
{
    public class ViewAddOrEdit:INotifyPropertyChanged
    {
        public Products _Products;

        public Products Product
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
                OnPropertyChanged();
            }
        }

        public ViewAddOrEdit()
        {
            Product=new Products();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
