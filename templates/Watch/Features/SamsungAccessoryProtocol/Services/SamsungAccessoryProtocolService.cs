using Samsung.Sap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides a service to exchange data with a paired phone using Samsung Accessory Protocol
    /// For more information about Samsung Accessory Protocol, see https://developer.samsung.com/galaxy-accessory/overview.html
    /// Check out samples to learn about Samsung Accessory Protocol API: https://developer.samsung.com/galaxy-watch-develop/samples/companion/overview.html
    /// </summary>
    public partial class SamsungAccessoryProtocolService
    {
        // TODO: Change the profile ID as appropriate for your application
        // Note: The profile ID must be the same as declared in the res/xml/accessoryservices.xml file
        private const string ProfileID = "/sample/accessoryservice";

        private Agent _agent;

        /// <summary>
        /// Initializes an agent
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            _agent = await Agent.GetAgent(profile: ProfileID, onConnect: OnConnect, onFileTransfer: OnFileTransferRequested, onMessage: OnMessageReceived);

            if (_agent == null)
            {
                // TODO: Failed to initialize a agent, insert code as appropriate to your scenario
            }
        }

        /// <summary>
        /// Finds a peer to exchange data and sends a message to the peer.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendMessageAsync(string message)
        {
            var peers = await _agent.FindPeers();
            if (peers.Any())
            {
                // TODO: Use the first peer of an array or search for a peer that matches the conditions
                var peer = peers.First();
                await peer.SendMessage(Encoding.UTF8.GetBytes(message));
            }
            else
            {
                // TODO: The peer is not found, insert code as appropriate to your scenario
            }
        }

        /// <summary>
        /// Called when a remote peer requests a connection
        /// </summary>
        /// <param name="connection">The incoming connection</param>
        /// <returns>true if the connection is accepted; otherwise, false.</returns>
        private bool OnConnect(Connection connection)
        {
            // TODO: Insert code to check for the incoming connection
            return true;
        }

        /// <summary>
        /// Called when the agent received a file transfer request from a peer.
        /// </summary>
        /// <param name="transfer">The file transfer request from the peer.</param>
        private void OnFileTransferRequested(IncomingFileTransfer transfer)
        {
            if (transfer == null)
            {
                throw new ArgumentNullException(nameof(transfer));
            }

            string sender = transfer.Peer.ApplicationName;
            string filename = transfer.FileName;
            string path = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Data, filename);

            Logger.Info($"sender:{sender}, file:{filename}");

            transfer.Progress += (s, e) =>
            {
                // TODO: Insert code to check file transfer progress
                Logger.Info($"file transfer progress: {e.Progress}");
            };

            transfer.Finished += (s, e) =>
            {
                // TODO: Insert code to check if file transfer has been succeeded or not
                Logger.Info($"file transfer result: {e.Result}");
            };

            // Remove a file if exists
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Start the transfer
            transfer.Receive(path);
        }

        /// <summary>
        /// Called when the agent received a message from a peer.
        /// </summary>
        /// <param name="peer">The peer sending the message.</param>
        /// <param name="buffer">An array of type Byte that contains the message.</param>
        private void OnMessageReceived(Peer peer, byte[] buffer)
        {
            var sender = peer.ApplicationName;
            var message = Encoding.UTF8.GetString(buffer);

            // TODO: Insert code to handle the message received here
            Logger.Info($"sender:{sender}, message:{message}");
        }
    }
}
