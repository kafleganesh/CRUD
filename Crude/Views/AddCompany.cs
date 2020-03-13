using System;
using System.Data.SqlTypes;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Crude.Views
{
    public class AddCompany : ContentPage
    {
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Entry _dateEntry;
        private Button _saveButton;

        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");

        public AddCompany()
        {
            this.Title = "Add company";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Numeric;
            _addressEntry.Placeholder = "Working Hours";
            stackLayout.Children.Add(_addressEntry);

            _dateEntry = new Entry();
            _dateEntry.Keyboard = Keyboard.Numeric;
            _dateEntry.Placeholder = "Enter date";
            stackLayout.Children.Add(_dateEntry);


            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;  
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<Company>();

            var maxPK = db.Table<Company>().OrderByDescending(c => c.Id).FirstOrDefault();

            Company company = new Company()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text,
                DateTime = _dateEntry.Text,
            };
            db.Insert(company);
            await DisplayAlert(null, "Saved", "Ok");
            await Navigation.PopAsync();
        }

    }
}

