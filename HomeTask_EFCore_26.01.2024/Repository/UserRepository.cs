using HomeTask_EFCore_26._01._2024.Data;
using HomeTask_EFCore_26._01._2024.Helpers;
using HomeTask_EFCore_26._01._2024.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_EFCore_26._01._2024.Repository
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool RegisteredUser(string userName, string password)
        {
            if (_context.Users.Any(e=>e.UserName == userName))
            {
                Console.WriteLine("User with this username already exists!");
                return false;
            }
            string salt = SecurityHelper.GenerateSalt(10101);
            string hashedPassword = SecurityHelper.HashPassword(password, salt, 10101,70);
            _context.Users.Add(new User
            {
                UserName = userName,
                Salt = salt,
                PasswordHash = hashedPassword
            });
            _context.SaveChanges();
            return true;
        }
        public bool AuthorizeUser(string userName, string password)
        {
            var currentUser = _context.Users.FirstOrDefault(e=>e.UserName.Equals(userName));
            if (currentUser != null && !currentUser.IsLocked) 
            {
                string hashedPassword = SecurityHelper.HashPassword(password, currentUser.Salt, 10101, 70);
                if (hashedPassword.Equals(currentUser.PasswordHash))
                {
                    currentUser.LoginAttempts = 0;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    currentUser.LoginAttempts++;
                    if(currentUser.LoginAttempts>=3)
                        currentUser.IsLocked = true;
                    _context.SaveChanges();
                    return false;
                }

            }
            return false;
        }
    }
}
