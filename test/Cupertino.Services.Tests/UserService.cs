using System.Threading.Tasks;
using Cupertino.Data.Entities;
using Xunit;

namespace Cupertino.Services.Tests
{
    public class UserService : Service
    {
        [Fact]
        public async Task DoLogin()
        {
            var userRepository = this.repositoryMocker.GetRepository<User>();

            await userRepository.InsertAsync(new User()
            {
                Email = "lucas@lorensoft.com.br",
                Password = "111"
            });

            var final = await userRepository.GetManyAsync(
                x => x.Email == "lucas@loresoft.com.br",
                x => new
                {
                    x.Password
                });

            //var userService = new Cupertino.Services.UserService(userRepository);



        }
    }
}
