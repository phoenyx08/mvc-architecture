using System;
using Microsoft.Extensions.DependencyInjection;

namespace PhoenyxStudio.Omdb
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddOmdbClient(this IServiceCollection serviceCollection, Action<ClientOptions> options)
        {
            serviceCollection.AddTransient<Client>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"ApiKey not provided");
            }
            serviceCollection.Configure(options);
            return serviceCollection;
        }
    }
}