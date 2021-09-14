using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public IEnumerable<User> GetAllUsers()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLineAsync().Result;
                        var user = new User
                        {
                            Name = line.Split(',')[0].ToString(),
                            Email = line.Split(',')[1].ToString(),
                            Phone = line.Split(',')[2].ToString(),
                            Address = line.Split(',')[3].ToString(),
                            UserType = line.Split(',')[4].ToString(),
                            Money = decimal.Parse(line.Split(',')[5].ToString()),
                        };

                        _users.Add(user);
                    }
                }
            }

            return _users;
        }
    }
}
