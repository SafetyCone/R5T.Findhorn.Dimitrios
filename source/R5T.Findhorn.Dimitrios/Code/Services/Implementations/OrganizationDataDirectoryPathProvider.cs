using System;

using R5T.Dalkeith;
using R5T.Dimitrios;
using R5T.Lombardy;using R5T.T0064;


namespace R5T.Findhorn.Dimitrios
{[ServiceImplementationMarker]
    public class OrganizationDataDirectoryPathProvider : IDataDirectoryPathProvider,IServiceImplementation
    {
        private IOrganizationDirectoryPathProvider OrganizationDirectoryPathProvider { get; }
        private IDataDirectoryNameConvention DataDirectoryNameConvention { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public OrganizationDataDirectoryPathProvider(
            IOrganizationDirectoryPathProvider organizationDirectoryPathProvider,
            IDataDirectoryNameConvention dataDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.OrganizationDirectoryPathProvider = organizationDirectoryPathProvider;
            this.DataDirectoryNameConvention = dataDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetDataDirectoryPath()
        {
            string organizationDirectoryPath = this.OrganizationDirectoryPathProvider.GetOrganizationDirectoryPath();

            string dataDirectoryName = this.DataDirectoryNameConvention.GetDataDirectoryName();

            string dataDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(organizationDirectoryPath, dataDirectoryName);
            return dataDirectoryPath;
        }
    }
}
