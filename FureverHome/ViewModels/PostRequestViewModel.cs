using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FureverHome.ViewModels
{
    internal class PostRequestViewModel:ViewModelBase
    {
        private readonly Post _post;

        public PostRequestViewModel(Post post)
        {
            _post = post;
        }
        public int Id => _post.Id;
        public string Title => _post.Title;
        public DateTime Date => _post.Date;
        public string Author => _post.Author.FirstName + " " + _post.Author.LastName;
        public string Name => _post.Animal.Name;
        public string Breed => _post.Animal.AnimalBreed.ToString();
        public string Color => _post.Animal.Color.Name;
        public string Health => _post.Animal.HealthStatus;
        public string Birthday => _post.Animal.BirthYear.ToString();
        public string Location => _post.Animal.FoundLocation;
    }
}
