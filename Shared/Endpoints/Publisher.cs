using NServiceBus;
using NServiceBus.Features;
using Shared.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Endpoints
{
    public class Publisher<T> : IDisposable where T : MessageBase
    {
        internal EndpointConfiguration endpointConfiguration;
        public IEndpointInstance endpointInstance;

        public Publisher(bool startImmediately = true)
        {
            var queueName = typeof(T).FullName + "_Publisher";

            endpointConfiguration = new EndpointConfiguration(queueName);
            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();

            //var transport = endpointConfiguration.UseTransport<LearningTransport>();
            //var routing = transport.Routing();
            //routing.RouteToEndpoint(typeof(Container.MessageContainer<T>), queueName);



            if (startImmediately) Start();
        }

        public void Start()
        {
            endpointInstance = Endpoint.Start(endpointConfiguration).Result;
        }

        public void Stop()
        {
            endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        public void Publish(Container.MessageContainer<T> mc)
        {
            endpointInstance.Publish(mc)
                .ConfigureAwait(false);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stop();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Endpoint() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
