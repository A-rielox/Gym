using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    //////////////////////////////////////////////////////////////////
    //              UsersController
    //////////////////////////////////////////////////////////////////
    Task<AppUser> GetUserByIdAsync(int id);
    Task<AppUser> GetUserByUserNameAsync(string username);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<bool> UpdateUserAsync(AppUser user);




    //////////////////////////////////////////////////////////////////
    //              AppUserStore
    //////////////////////////////////////////////////////////////////
    Task<int> CreateUser(AppUser usuario);
    Task<AppUser> GetUserByUserNameStoreAsync(string username);
    Task<AppUser> GetUserWithMainFotoAsync(string userName);





    //Task<int> AddPhotoAsync(Photo photo);
    //Task<bool> UpdatePhotos(SetMainPhoto setMainPhoto);
    //Task<bool> DeletePhoto(int id);
}

// ANTIGUO
//Task<bool> UpdatePhotos(List<Photo> photos);
