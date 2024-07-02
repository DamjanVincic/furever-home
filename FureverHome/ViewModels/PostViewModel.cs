﻿using System.Windows.Input;
using FureverHome.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FureverHome.Views;

namespace FureverHome.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        private readonly Post _post;

        public PostViewModel(Post post)
        {
            _post = post;
            CommentCommand = new RelayCommand(ViewComments);
        }

        public int Id => _post.Id;
        public string Title => _post.Title;
        public string ImageLink => _post.ImageLink;
        public DateTime Date => _post.Date;
        public PostStatus Status => _post.Status;
        public string Author => _post.Author.FirstName + " " + _post.Author.LastName;
        public Animal Animal => _post.Animal;
        public string AnimalBreed => _post.Animal.AnimalBreed.Name;
        public string AnimalSpecies => _post.Animal.AnimalBreed.AnimalSpecies.Name;
        public string AnimalColor => _post.Animal.Color.Name;
        public string AnimalState => _post.Animal.HealthStatus;
        public string AnimalYear => _post.Animal.BirthYear.ToString();
        public string AnimalLocation => _post.Animal.FoundLocation;
        public ICommand CommentCommand { get; }

        private void ViewComments()
        {
            var newWindow = new CommentsListing(Id);
            newWindow.ShowDialog();
        }
    }
}