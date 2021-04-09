using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class LeaderBoardDto 
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
