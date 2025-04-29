using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiFilm.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new();

        public override Task OnConnectedAsync() 
        {
            return base.OnConnectedAsync();
        }

        

        public async Task SendMessage(string user, string message, string movie)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, movie);

            

        }


        public async Task SendPhoto(string user, string photoPath, string movie)
        {
            await Clients.All.SendAsync("ReceivePhoto", user, photoPath, movie);
        }

        public async Task RegisterUser(string username)
        {
            Users[username] = Context.ConnectionId;


        }

        public async Task SendMessageLs(string recipient, string user, string message)
        {
            if (Users.TryGetValue(recipient, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessageLs", user, message);
            }


        }
        
        public async Task SendPhotoLs(string recipient, string user, string photoPath)
        {
            if (Users.TryGetValue(recipient, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceivePhotoLs", user, photoPath);
            }


        }


    }
}


        //if (Users.TryGetValue(recipient, out var connectionId))
            //{
            //await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message);
            //}

        /*string recipient,*/

        //public async Task SendMessage(string recipient, string user, string message, string movName)
        //{
        //    if (Users.TryGetValue(recipient, out var connectionId))
        //    { 
        //          await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message, movName);
        //    }


        //}

        //public async Task SendMessageMov(string user, string message, int? movieId)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage1", user, message, movieId);
        //}

        //// Отправка фото всем пользователям
        //public async Task SendPhoto(string user, string filePath, int messageId)
        //{
        //    await Clients.All.SendAsync("ReceivePhoto", user, filePath, messageId);
        //}


