using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace agiprog.Data
{
    public class BlazorChatSampleHub : Hub
    {
        public const string HubUrl = "/chat";


        public override Task OnConnectedAsync()
        {
       
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

  

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

        public async Task JoinGroup(int step, String meeting)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,step + meeting);
        }

        public async Task LeaveRoomAsync(int step, String meeting)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, step + meeting);
        }


        public async Task SendMessageToGroup(int step, String meeting, MessageBody message)
        {
            await Clients.Group(step + meeting).SendAsync("RecieveMessage", message);
        }

        public async Task SendDeleteMessageToGroup(int step, String meeting, int messageId)
        {
            await Clients.Group(step + meeting).SendAsync("RecieveDeleteMessage", messageId);
        }
    }
}