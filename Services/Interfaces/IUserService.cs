using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Models.Dtos;

namespace AgendaApi.Services.Interfaces
{
    public interface IUserService
    {
        void Archive(int id);
        bool CheckIfUserExists(int userId);
        void Create(CreateAndUpdateUserDto dto);
        void Delete(int id);
        List<UserDto> GetAll();
        User? GetById(int userId);
        void Update(CreateAndUpdateUserDto dto, int userId);
        User? ValidateUser(AuthenticationRequestDto authRequestBody);
    }
}