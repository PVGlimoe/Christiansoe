using System;

namespace Christiansoe.DTO 
{
    [Serializable]
    public class UserBingoBoardDTO {
        public int BingoBoardId { get; set; }
        public string UserId { get; set; }
        public bool Done { get; set; }
        public int Id { get; set; }
    }
}
