using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using BusinessObject;
using Common;

namespace BusinessFascadeServiceProxyLib
{
    //Factory class for client proxy
    public abstract class ClientFactory
    {
        public static T CreateClient<T>(ServiceType serviceType = ServiceType.Local) where T : class
        {
            switch (serviceType)
            {
                case ServiceType.Local:
                    return GetLocalServiceInstance<T>();
                default:
                    return GetRemoteServiceInstance<T>();
            }

        }

        private static T GetLocalServiceInstance<T>() where T:class 
        {
            return BusinessObjectFactory.GetInstance<T>();
        }

        private static T GetRemoteServiceInstance<T>()
        {
            ChannelEndpointElement clientEndpointAddress = GetClientEndpointAddress(typeof (T));
            BasicHttpBinding binding = new BasicHttpBinding();
            //dynamic factory generation
            ChannelFactory<T> factory = Activator.CreateInstance(typeof
                (ChannelFactory<>).MakeGenericType(typeof(T)), clientEndpointAddress.Binding, clientEndpointAddress.Address) as
                ChannelFactory<T>;
            return factory.CreateChannel();
        }

        public static ChannelEndpointElement GetClientEndpointAddress(Type serviceType)
        {
            string address;
            var clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            for (int i = 0; i < clientSection.Endpoints.Count; i++)
            {
                if (clientSection.Endpoints[i].Name == serviceType.FullName)
                    return clientSection.Endpoints[i];
            }
            return null;
        }
    }
}
