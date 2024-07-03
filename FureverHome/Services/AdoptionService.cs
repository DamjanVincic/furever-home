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

    public List<AdoptionRequest> GetUnapproved()
    {
        return _adoptionRequestRepository.GetAll().Where(ar => !ar.Approved).ToList();
    }
    
    public int Add(int postId, int userId, int duration, bool permanent)
    {
        CanAdopt(postId, userId);
        AdoptionRequest adoptionRequest = new AdoptionRequest(duration, permanent, postId, userId);
        return _adoptionRequestRepository.Add(adoptionRequest);
    }
    
    public void CanAdopt(int postId,int userId)
    {
        foreach(AdoptionRequest adoptionReqiest in _postRepository.GetById(postId).AdoptionRequests) { 
            if(adoptionReqiest.User.Id == userId)
            {
                throw new InvalidInputException("You have alrady sent request for this animal.");
            }
        }
    }
    public void ReviewRequest(int requestId, bool isApproved)
    {
        AdoptionRequest adoptionRequest = _adoptionRequestRepository.GetById(requestId)!;
        if (isApproved)
        {
            adoptionRequest.Approved = true;
            _adoptionRequestRepository.Update(adoptionRequest);
            
            Post post = adoptionRequest.Post;
            post.Status = PostStatus.Adopted;
            _postRepository.Update(post);
            
            DeletePostAdoptionRequests(adoptionRequest.PostId, adoptionRequest.UserId);
        }
        else
        {
            _adoptionRequestRepository.Delete(requestId);
        }
    }

    private void DeletePostAdoptionRequests(int postId, int userId)
    {
        foreach (int adoptionRequestId in _adoptionRequestRepository.GetAll().Where(ar => ar.PostId == postId && ar.UserId != userId).Select(ar => ar.Id))
        {
            _adoptionRequestRepository.Delete(adoptionRequestId);
        }
    }
}