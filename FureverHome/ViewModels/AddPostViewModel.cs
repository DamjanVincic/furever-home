using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    public class AddPostViewModel:ViewModelBase
    {
        private readonly AnimalBreedService _animalBreedService =
            ServiceProvider.GetRequiredService<AnimalBreedService>();
        private readonly ColorService _colorService = ServiceProvider.GetRequiredService<ColorService>();
        private readonly PostService _postService=ServiceProvider.GetRequiredService<PostService>();

        private readonly Window _cureentWindow;

        public AddPostViewModel(Window currentWindow)
        {
            _cureentWindow=currentWindow;

            AddCommand = new RelayCommand(AddPost);
        }

        public ICommand AddCommand { get; }

        public IEnumerable<AnimalBreed> AnimalBreeds => _animalBreedService.getAll();
        public IEnumerable<Color> Colors => _colorService.getAll();
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HealthStatus { get; set; }
        public DateTime Birthday { get; set; }
        public Color SelectedColor { get; set; }
        public AnimalBreed? SelectedBreed { get; set; }

        public void AddPost()
        {
            try
            {
                if (SelectedBreed == null)
                    throw new InvalidInputException("No breed selected");

                if (SelectedColor == null)
                    throw new InvalidInputException("No color selected");
                //TODO: use logged in user id
                _postService.Add(Title, ImageLink, Name, Location, HealthStatus, Birthday, SelectedBreed.Id, SelectedColor.Id, 2);
                MessageBox.Show("Post added successfully.", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                _cureentWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
