using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services;

public class AdoptionService
{
    private readonly IAdoptionRequestRepository _adoptionRequestRepository;
    private readonly IAnimalRepository _animalRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    
    public AdoptionService(IAdoptionRequestRepository adoptionRequestRepository, IAnimalRepository animalRepository,
        IPostRepository postRepository, IUserRepository userRepository)
    {
        _adoptionRequestRepository = adoptionRequestRepository;
        _animalRepository = animalRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }
    
    public void Add(int postId, int userId, int duration, bool permanent)
    {
        AdoptionRequest adoptionRequest = new AdoptionRequest(duration, permanent, postId, userId);
        _adoptionRequestRepository.Add(adoptionRequest);
    }
    
    public void ReviewRequest(int requestId, int volunteerId, bool isApproved)
    {
        User user = _userRepository.GetById(volunteerId)!;
        if (user is not Volunteer)
            throw new InvalidInputException("User is not a volunteer.");
        
        AdoptionRequest adoptionRequest = _adoptionRequestRepository.GetById(requestId)!;
        if (isApproved)
        {
            adoptionRequest.Approved = true;
            _adoptionRequestRepository.Update(adoptionRequest);
            
            Post post = adoptionRequest.Post;
            post.Status = PostStatus.Adopted;
            _postRepository.Update(post);
        }
        else
        {
            _adoptionRequestRepository.Delete(requestId);
        }
    }
}