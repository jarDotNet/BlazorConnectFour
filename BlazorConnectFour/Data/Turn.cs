using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConnectFour.Data
{
    public class Turn
    {
        public DiscColor Color { get; }
        public string Emoji { get; }

        public Turn(DiscColor color, string emoji)
        {
            Color = color;
            Emoji = emoji;
        }
    }
}
