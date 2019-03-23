using Cupertino.Core;
using Cupertino.Services.Tests.Mockers;

namespace Cupertino.Services.Tests
{
    public class Service : IService
    {
        internal readonly RepositoryMocker repositoryMocker;

        public Service()
        {
            this.repositoryMocker = new RepositoryMocker();
        }
    }
}
