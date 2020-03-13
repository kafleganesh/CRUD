using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Crude.Views
{
    public class GetAllCompaniesPage : ContentPage
    {
        private ListView _listView;
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");

        public GetAllCompaniesPage()
        {
            this.Title = "Companies";
            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();

            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();

            stackLayout.Children.Add(_listView);
            Content = stackLayout;

        }
    }
}

