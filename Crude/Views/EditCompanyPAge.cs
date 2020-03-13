using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Crude.Views
{
    public class EditCompanyPAge : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Entry _dateEntry;
        private Button _button;

        Company _company = new Company();
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");

        public EditCompanyPAge()
        {
            this.Title = "Edit Page";
            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Compamy Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Working Hours";
            stackLayout.Children.Add(_addressEntry);

            _dateEntry = new Entry();
            _dateEntry.Keyboard = Keyboard.Default;
            _dateEntry.Placeholder = "Date";
            stackLayout.Children.Add(_dateEntry);


            _button = new Button();
            _button.Text = "Update";
            stackLayout.Children.Add(_button);
            _button.Clicked += _button_Clicked;



            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);

            Company company = new Company()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text,
                DateTime = _dateEntry.Text,

            };
            db.Update(company);
            await Navigation.PopAsync();
        }


        void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;
            _idEntry.Text = _company.Id.ToString();
            _nameEntry.Text = _company.Name;
            _addressEntry.Text = _company.Address;
            _dateEntry.Text = _company.DateTime;
       }

    }
}

