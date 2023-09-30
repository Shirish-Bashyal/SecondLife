using SecondLife.DTO;
using SecondLife.Models;

namespace SecondLife.Interfaces
{
    public interface IUser
    {

        UserDetails GetUserDetails(int id);

        Task<UserManagerResponse> AddUserDetailsAsync(UserDetailsDTO userDetail);


        Task<UserManagerResponse> UpdateUserDetailsAsync(UserDetailsDTO userDetail);

        bool save();



    }
}
