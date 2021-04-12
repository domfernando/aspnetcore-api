using System.Linq;
using System.Collections.Generic;
using Core.Models;

namespace Core.Repository
{
    public static class UserRepo
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, UserName = "Batman", Password = "dc", Role = "Gerente" });
            users.Add(new User { Id = 2, UserName = "Ironman", Password = "marvel", Role = "Gerente" });
            users.Add(new User { Id = 3, UserName = "Robin", Password = "dc", Role = "Funcionário" });
            users.Add(new User { Id = 4, UserName = "Spiderman", Password = "marvel", Role = "Funcionário" });

            return users.Where(x => x.UserName.ToLower() == userName && x.Password == password).FirstOrDefault();
        }
    }

}