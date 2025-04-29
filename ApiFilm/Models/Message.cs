namespace ApiFilm.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; } // Текст сообщения
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; } // ID пользователя
        public int? MovieId { get; set; } // ID фильма (может быть null)
        public string? Url { get; set; }
    }


    public class LsMessage
    {
        public int Id { get; set; }
        public string? Content { get; set; } // Текст сообщения
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId1 { get; set; } // ID пользователя

        public int UserId2 { get; set; } // ID пользовател
        public string? Url { get; set; }
    }

}
