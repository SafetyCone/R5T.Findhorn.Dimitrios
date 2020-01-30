using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Dalkeith;
using R5T.Dimitrios;
using R5T.Lombardy;


namespace R5T.Findhorn.Dimitrios
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OrganizationDataDirectoryPathProvider"/> implementation of <see cref="IDataDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOrganizationDataDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IOrganizationDirectoryPathProvider> addOrganizationDirectoryPathProvider,
            ServiceAction<IDataDirectoryNameConvention> addDataDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IDataDirectoryPathProvider, OrganizationDataDirectoryPathProvider>()
                .RunServiceAction(addOrganizationDirectoryPathProvider)
                .RunServiceAction(addDataDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OrganizationDataDirectoryPathProvider"/> implementation of <see cref="IDataDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IDataDirectoryPathProvider> AddOrganizationDataDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IOrganizationDirectoryPathProvider> addOrganizationDirectoryPathProvider,
            ServiceAction<IDataDirectoryNameConvention> addDataDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IDataDirectoryPathProvider>(() => services.AddOrganizationDataDirectoryPathProvider(
                addOrganizationDirectoryPathProvider,
                addDataDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
