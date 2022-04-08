using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppList.Models;
using AppList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsProduct : ContentPage
    {
        public DetailsProduct(Products products=null)
        {
            InitializeComponent();
            if (products != null)
            {
                ((ViewAddOrEdit)BindingContext).Product = products;
            }
        }
    }
}