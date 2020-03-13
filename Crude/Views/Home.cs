using System;

using Xamarin.Forms;

namespace Crude.Views
{
    public class Home : ContentPage
    {
        public Home()
        {
            this.Title = "Select Option";
            StackLayout stackLayout = new StackLayout();

            Button button = new Button();
            button.Text = "Add company and Worked Hours";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Get company and Working Hours";
            button.Clicked += Button_GetClicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit company and Working Hours";
            button.Clicked += Button_EditClicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete ";
            button.Clicked += Button_DeleteClicked;
            stackLayout.Children.Add(button);


            Content = stackLayout;
        }

        private async void Button_DeleteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());
        }

        private async void Button_EditClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPAge());
        }

        private async void Button_GetClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompaniesPage());
        }   

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompany());
        }

    }
}

