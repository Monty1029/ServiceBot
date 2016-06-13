using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;

namespace ServiceBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // calculate something for us to return
                int length = (message.Text ?? string.Empty).Length;

                // return our reply to the user
                EchoDialog echo = new EchoDialog();
                return await Conversation.SendAsync(message, () => echo);
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                return message.CreateReplyMessage($"ServiceBot has joined the conversation. Type /edit to begin or /help for a list of commands.");
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
                return message.CreateReplyMessage($"ServiceBot has left the conversation.");
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }

    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<Message> argument)
        {
            var message = await argument;
            if (message.Text.Contains("/edit"))
            {
                PromptDialog.Confirm(
                    context, //context
                    AfterResetAsync, //resume handler
                    "Would you like to modify your profile?", //prompt to show to the user
                    "Sorry, I don't understand."); //what to show on retry
            }
            else
            {
                await context.PostAsync(string.Format("You said: {0}", message.Text));
                context.Wait(MessageReceivedAsync);
            }
        }
        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                await context.PostAsync("What would you like to modify?");
            }
            else
            {
                await context.PostAsync("Okay, enjoy your time on the forum.");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}