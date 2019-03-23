using Cupertino.Services.Tests.Mockers;

namespace Cupertino.Services.Tests
{
    public class Service
    {
        internal readonly RepositoryMocker repositoryMocker;

        public Service()
        {
            this.repositoryMocker = new RepositoryMocker();
        }
    }
}
