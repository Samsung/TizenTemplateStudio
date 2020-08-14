using System;
using Tizen.Applications;
using Tizen.Applications.Messages;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides functionalities for communicating with each other.
    /// For more information, see https://docs.tizen.org/application/dotnet/guides/app-management/message-port/.
    /// </summary>
    public class MessagePortService : IDisposable
    {
        private MessagePort _localPort;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePortService"/> class.
        /// </summary>
        /// <param name="localPort">The name of local message port to register.</param>
        /// <param name="trusted">If true, a message is exchanged over a trusted message port.</param>
        public MessagePortService(string localPort, bool trusted)
        {
            _localPort = new MessagePort(localPort, trusted);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MessagePortService"/> class.
        /// </summary>
        ~MessagePortService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Occurs when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Registers the local message port.
        /// </summary>
        /// <remarks>
        /// Before using a message port, you must call this function.
        /// </remarks>
        public void Open()
        {
            if (!_localPort.Listening)
            {
                _localPort.MessageReceived += OnMessageReceived;
                _localPort.Listen();
            }
        }

        /// <summary>
        /// Sends a message over message port.
        /// </summary>
        /// <param name="message">The message to send. The recommended message size is under 4KB.</param>
        /// <param name="remotePort">The remote port to which a message is sent</param>
        /// <remarks>
        /// Before calling this function, you must call Open().
        /// In addition, you can check if a remote port is running by RemotePort.IsRunning() and RemotePort.RemotePortStateChanged event.
        /// For more details, see https://docs.tizen.org/application/dotnet/guides/app-management/message-port/#managing-a-remote-port.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The passed arguments is null but should never be null.</exception>
        public void Send(Bundle message, RemotePort remotePort)
        {
            if (remotePort == null)
            {
                throw new ArgumentNullException(nameof(remotePort));
            }

            Send(message, remotePort.AppId, remotePort.PortName);
        }

        /// <summary>
        /// Sends a message over message port.
        /// </summary>
        /// <param name="message">The message to send. The recommended message size is under 4KB.</param>
        /// <param name="remoteAppId">The ID of the remote application to which a message is sent</param>
        /// <param name="remotePort">The name of the remote port to which a message is sent</param>
        /// <remarks>
        /// Before calling this function, you must call Open().
        /// In addition, you can check if a remote port is running by RemotePort.IsRunning() and RemotePort.RemotePortStateChanged event.
        /// For more details, see https://docs.tizen.org/application/dotnet/guides/app-management/message-port/#managing-a-remote-port.
        /// </remarks>
        public void Send(Bundle message, string remoteAppId, string remotePort)
        {
            _localPort.Send(message, remoteAppId, remotePort, _localPort.Trusted);
        }

        /// <summary>
        /// Unregister the local message port.
        /// </summary>
        public void Close()
        {
            if (_localPort.Listening)
            {
                _localPort.MessageReceived -= OnMessageReceived;
                _localPort.StopListening();
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method or from a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_localPort != null)
                {
                    Close();
                    _localPort.Dispose();
                }
            }

            _disposed = true;
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(sender, e);
            // TODO: Handle received message.
        }
    }
}
