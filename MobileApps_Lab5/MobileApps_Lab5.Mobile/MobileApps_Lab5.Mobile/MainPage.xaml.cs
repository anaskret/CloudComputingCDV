using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps_Lab5.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection hubConnection;

        public MainPage()
        {
            InitializeComponent();

            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chathub")
                .Build();

            hubConnection.On("ReceiveMessage", ReceiveMessage_Event);
            hubConnection.StartAsync();
        }

        private void ReceiveMessage_Event(string user, string message)
        {

        }
    }
}
