using System;
using System.Collections.Generic;
using Smykkeskrin.model;
using Smykkeskrin.Repo;

/// <summary>
/// Opsummeret: DI fra IUserRepo så vi kan tjekke rollen på den user der vil oprette opslag samt validere, ellers kastes fejl
/// der bruges IEnumerable i stedet for List fordi.. 
/// </summary>

namespace Smykkeskrin.Services
{
    public class FeedService
    {
        private readonly IFeedRepository _feedRepository;
        private readonly IUserRepository _userRepository; //Så vi også kan tjekke rollen på user

        public FeedService(IFeedRepository feedRepository, IUserRepository userRepository)
        {
            _feedRepository = feedRepository;
            _userRepository = userRepository;
        }

        // Create post/feed
        public Feed CreateFeed(string description, int userId)
        {
            var user = _userRepository.GetUserById(userId); 

            if (user == null)
            {
                throw new Exception("Brugeren blev ikke fundet.");
            }

            if (user.UserRole != User.Role.Vip)
            {
                throw new UnauthorizedAccessException("Kun brugere med VIP-status kan oprette opslag i feedet.");
            }

            //Hvis brugeren er VIP, oprettes opslaget som normalt
            var feed = new Feed
            {
                Description = description,
                CreatedOn = DateTime.Now,
                UserId = userId
            };

            return _feedRepository.Add(feed);
        }

        // Read (all feeds)
        public IEnumerable<Feed> GetAllFeeds()
        {
            return _feedRepository.GetAll();
        }

        // Read (one feed)
        public Feed GetFeedById(int id)
        {
            return _feedRepository.GetById(id);
        }

        // Update feed
        public void UpdateFeed(int id, string description)
        {
            var feed = _feedRepository.GetById(id);
            if (feed != null)
            {
                feed.Description = description;
                _feedRepository.Update(feed);
            }
        }

        // Delete
        public void DeleteFeed(int id)
        {
            _feedRepository.Delete(id);
        }
    }
}
