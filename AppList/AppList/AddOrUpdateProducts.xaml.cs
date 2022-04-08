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
    public partial class AddOrUpdateProducts : ContentPage
    {
        public AddOrUpdateProducts(Products products=null)
        {
            InitializeComponent();
            if (products != null)
            {
                ((ViewAddOrEdit) BindingContext).Product = products;
            }
        }

        private async void BtnRegister_OnClicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                Products products = ((ViewAddOrEdit)BindingContext).Product;
                MessagingCenter.Send(this, "AddOrUpdateProduct", products);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Digite todos los campos", "OK!");
            }
            
        }
        public bool Validate()
        {
            bool answer;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                answer = false;
            }else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                answer = false;
            }else if (string.IsNullOrEmpty(txtQuanty.Text))
            {
                answer =false;
            }else if (string.IsNullOrEmpty(txtDescrip.Text))
            {
                answer=false;
            }
            else
            {
                answer = true;
            }

            return answer;
        }
    }

   
}