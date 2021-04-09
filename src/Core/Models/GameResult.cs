using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class GameResult
    {
        public long GameId { get; set; }
        public long PlayerId { get; set; }
        public long Win { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
