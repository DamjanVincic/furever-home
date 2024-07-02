using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using FureverHome.Repositories;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace FureverHome.Services
{
    internal class PostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IAnimalRepository animalRepository,
            IUserRepository userRepository)
        {
            _postRepository=postRepository;
            _animalRepository=animalRepository;
            _userRepository=userRepository;
        }

        public void Add(string title, string imageLink, DateTime date, string name, string foundLocation,
            string healthStatus, DateTime birthYear,
            int animalBreedId, int colorId, int authorId)
        {
            Animal animal = new Animal(name, foundLocation, healthStatus, birthYear, animalBreedId, colorId);
            int animalId = _animalRepository.Add(animal);
            User author = _userRepository.GetById(authorId);
            bool isApproved = author is Volunteer;
            Post post = new Post(title, imageLink, date, PostStatus.Active, isApproved, authorId, animalId);
            _postRepository.Add(post);
        }

        public void SubmitReview(int postId, bool isApproved)
        {
            Post post = _postRepository.GetById(postId);
            if (isApproved)
            {
                post.IsApproved = isApproved;
                _postRepository.Update(post);
            }
            else
            {
                //TODO: delete post
            }
        }
    }
}
