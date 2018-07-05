using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public List<Card> playerInPlay = new List<Card>();

        public List<Point> playerCardPos = new List<Point> { new Point(465, 388), new Point(390, 388), new Point(315, 388), new Point(240, 388), new Point(165, 388), new Point(90, 388) };

        public int playerTotal = 0;

    }
}
