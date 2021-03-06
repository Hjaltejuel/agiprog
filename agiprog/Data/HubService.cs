﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agiprog.Data
{
    public class HubService
    {
        private string _hubUrl;
        private HubConnection _hubConnection;
        private readonly NavigationManager NavigationManager;

        public HubService(NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        public async Task StartConnectionAsync(Action<MessageBody> RecieveMessage, Action<int> RecieveDeleteMessage)
        {
            string baseUrl = NavigationManager.BaseUri;

            _hubUrl = baseUrl.TrimEnd('/') + BlazorChatSampleHub.HubUrl;
            // Create the connection
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_hubUrl) // _hubUrl is your base Url + Hub Url
                .Build();
            // Add Handler for when a client receives a broadcast message
            _hubConnection.On<MessageBody>("RecieveMessage", RecieveMessage);
            _hubConnection.On<int>("RecieveDeleteMessage", RecieveDeleteMessage);
            // Then you start the connection
            await _hubConnection.StartAsync();
        }

        public async Task Disconect(int step, String meeting, string username)
        {
            await _hubConnection.SendAsync("LeaveRoomAsync", step, meeting);
            await _hubConnection.SendAsync("SendMessageToGroup",step,meeting, new MessageBody() { User = username, Chat = $"[Notice] {username} left chat room.", At = DateTime.Now });
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }

        public async Task JoinGroup(int step, String meeting, string username)
        {
            await _hubConnection.SendAsync("JoinGroup",step,meeting);
            await _hubConnection.SendAsync("SendMessageToGroup", step, meeting, new MessageBody() { User = username, Chat = $"[Notice] {username} joined chat room.", At = DateTime.Now });
        }


        public async Task SendMessageToGroup(int step, String meeting, MessageBody message)
        {
            await _hubConnection.SendAsync("SendMessageToGroup", step, meeting, message);
        }


        public async Task SendDeleteMessageToGroup(int step, String meeting, int messageId)
        {
            await _hubConnection.SendAsync("SendDeleteMessageToGroup", step, meeting, messageId);
        }
    }
}
