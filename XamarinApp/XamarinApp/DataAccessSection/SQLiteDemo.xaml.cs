﻿
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Persistance;

namespace XamarinApp.DataAccessSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteDemo : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;


        public SQLiteDemo()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        private async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };

            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
        }

        private async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " UPDATED";

            await _connection.UpdateAsync(recipe);
        }

        private async void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];

            await _connection.DeleteAsync(recipe);

            _recipes.Remove(recipe);
        }
    }

    public class Recipe : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
            }
        }

        private string _name;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}