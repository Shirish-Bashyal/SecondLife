using SecondLife.Data;
using SecondLife.DTO;
using SecondLife.Interfaces;
using SecondLife.Models;

namespace SecondLife.Repositories
{
    public class UserRepository : IUser
    {
        public ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> AddUserDetailsAsync(UserDetailsDTO userDetail)
        {
            var user = new UserDetails  // creating an instance of userdetails to save to database
            {
                Name = userDetail.Name,
                AboutMe = userDetail.AboutMe,
                PhoneNumber = userDetail.PhoneNumber,
                Address = userDetail.Address,
                Email = userDetail.Email


            };
            _context.tbl_user_details.Add(user);
            var saved = save();

            var result = new UserManagerResponse
            {
                IsSuccess=saved,


            };

            return result;




           
        }

        public UserDetails GetUserDetails(int id)
        {

          var user=  _context.tbl_user_details.Where(a => a.Id == id).FirstOrDefault();
            return user;

           
            
            
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public Task<UserManagerResponse> UpdateUserDetailsAsync(UserDetailsDTO userDetail)
        {
            throw new NotImplementedException();
        }
    }
}
