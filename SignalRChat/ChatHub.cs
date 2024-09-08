using System;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
 
            Clients.All.addNewMessageToPage(name, message);
        }

        public async Task JoinChat(string name)
        {
            await Clients.All.addNewMessageToPage($"{name} has joined the chat.", true);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.QueryString["name"];
            Clients.All.addNewMessageToPage($"{name} has left the chat.", false);
            return base.OnDisconnected(stopCalled);
        }
    }
}