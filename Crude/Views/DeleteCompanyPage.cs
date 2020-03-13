using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Crude.Views
{
    public class DeleteCompanyPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Company company = new Company();
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");

        public DeleteCompanyPage()
        {
            this.Title = "Delete Page";
            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            stackLayout.Children.Add(_button);
            _button.Clicked += _button_Clicked;


            Content = stackLayout;
        }
        void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.Table<Company>().Delete(x => x.Id == company.Id);
            await Navigation.PopAsync();
        }
    }
}

