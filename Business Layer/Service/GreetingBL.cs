using Business_Layer.Interface;
using Model_Layer.Model;
using Repository_Layer.Entity;
using Repository_Layer.Interface;

namespace Business_Layer.Service
{

    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;
        private readonly RedisCacheService _cacheService;


        public GreetingBL(IGreetingRL _greetingRL, RedisCacheService cacheService)
        {
            this._greetingRL = _greetingRL;
            _cacheService = cacheService;
        }
        public async Task<GreetingEntity> UpdateGreeting(int id, string newMessage)
        {
            var updatedGreeting = _greetingRL.UpdateGreeting(id, newMessage);
            if (updatedGreeting != null)
            {
                await _cacheService.SetAsync($"greeting:{id}", updatedGreeting, TimeSpan.FromMinutes(10));
            }
            return updatedGreeting;
        }


        public async Task<bool> DeleteGreeting(int id)
        {
            bool result = await Task.Run(() => _greetingRL.DeleteGreeting(id));
            if (result)
            {
                await _cacheService.RemoveAsync($"greeting:{id}");
            }
            return result;
        }





        public List<GreetingEntity> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings();
        }



        public async Task<GreetingEntity> GetGreetingById(int id)
        {
            string cacheKey = $"greeting:{id}";
            var cachedGreeting = await _cacheService.GetAsync<GreetingEntity>(cacheKey);

            if (cachedGreeting != null)
            {
                return cachedGreeting;
            }

            var greeting = _greetingRL.GetGreetingById(id);
            if (greeting != null)
            {
                await _cacheService.SetAsync(cacheKey, greeting, TimeSpan.FromMinutes(10));
            }

            return greeting;
        }
        public string GetGreeting()
        {
            return "Hello World";
        }
        public string PersonalizedGreeting(UserModel userModel)
        {
            if (userModel.FirstName != null && userModel.LastName != null)
            {
                return "Hello " + userModel.FirstName + " " + userModel.LastName;
            }
            else if (userModel.FirstName != null && userModel.LastName == null)
            {
                return "Hello " + userModel.FirstName;
            }
            else if (userModel.FirstName == null && userModel.LastName != null)
            {
                return "Hello " + userModel.LastName;
            }
            else
            {
                return "Hello World";
            }
        }
    }
}
