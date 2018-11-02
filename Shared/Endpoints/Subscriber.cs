using NServiceBus;
using NServiceBus.Features;
using Shared.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Endpoints
{
    public class Subscriber<T> : IDisposable where T : MessageBase
    {
        private EndpointConfiguration endpointConfiguration;
        private IEndpointInstance endpointInstance;
        private AssemblyScannerConfiguration scanner;

        public Subscriber(bool startImmediately = true)
        {
            var queueName = typeof(T).FullName + "_Subscriber";
            
            endpointConfiguration = new EndpointConfiguration(queueName);
            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();

            if (startImmediately) Start();
        }

        public void Start()
        {
            var startableEndpoint = Endpoint.Create(endpointConfiguration).Result;
            endpointInstance = startableEndpoint.Start().Result;

            endpointInstance.Subscribe<Container.MessageContainer<T>>().Wait();
        }

        public void Stop()
        {
            endpointInstance.Stop()
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