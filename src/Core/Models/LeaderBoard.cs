using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class LeaderBoard
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
