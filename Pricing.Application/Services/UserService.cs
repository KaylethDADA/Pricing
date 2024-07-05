using MapsterMapper;
using Pricing.Application.Dtos.User;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;

namespace Pricing.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Create(UserCreateRequests request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.Create(user);
            return _mapper.Map<UserResponse>(user);
        }
        public UserResponse Update(UserUpdateRequests request)
        {
            var user = _userRepository.GetById(request.Id);

            if (user == null)
                throw new Exception();

            user.Update(
                request.FullName.FirstName,
                request.FullName.LastName,
                request.FullName.MiddleName,
                request.Email);

            _userRepository.Update(user);

            return _mapper.Map<UserResponse>(user);
        }
        public UserResponse GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserResponse>(user);
        }
        public List<UserItemList> GetAll() 
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserItemList>>(users);
        }
        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }
    }
}
