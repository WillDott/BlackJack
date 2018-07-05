using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Blackjack
{
    public class Dealer
    {
        public int dealerTotal = 0;

        public List<Card> dealerInPlay = new List<Card>();

        List<Point> dealerCardPos = new List<Point> { new Point(466, 51), new Point(391, 51), new Point(316, 51), new Point(241, 51), new Point(166, 51), new Point(91, 51) };

       
        
        //Rewrite Check
        public void dealerPlay(Player p, Form1 f, Deck d)
        {
            while(dealerTotal < 22)
            {
                if (dealerTotal < 17)
                {
                    dealCards(1, 0, p, f, d);
                }
                else
                {
                    break;
                }
            }
            d.flipAll(true);
            MessageBox.Show(Convert.ToString(dealerTotal));
            f.whoWon();
        }

        public void dealCards(int dealer, int player, Player p, Form1 f, Deck d)
        {
            int total = player + dealer;

            for (int i = 0; i < total; i++)
            {
                Card toPlay = trueRandom(d, p);

                if (i < dealer)
                {
                    dealerInPlay.Add(toPlay);
                    f.addcard(toPlay, dealerCardPos[dealerInPlay.Count - 1]);
                    dealerTotal += toPlay.value;
                }
                else
                {
                    p.playerInPlay.Add(toPlay);
                    f.addcard(toPlay, p.playerCardPos[p.playerInPlay.Count - 1]);
                    p.playerTotal += toPlay.value;
                }

                f.lblTotal.Text = Convert.ToString(p.playerTotal);
            }

        }

        public void dealChip(int dealer, int player, Player p, Form1 f, Deck d)
        {
            int total = player + dealer;

            for (int i = 0; i < total; i++)
            {
                Card toPlay = trueRandom(d, p);

                if (i < dealer)
                {
                    dealerInPlay.Add(toPlay);
                    f.addcard(toPlay, dealerCardPos[dealerInPlay.Count - 1]);
                    dealerTotal += toPlay.value;
                }
                else
                {
                    p.playerInPlay.Add(toPlay);
                    f.addcard(toPlay, p.playerCardPos[p.playerInPlay.Count - 1]);
                    p.playerTotal += toPlay.value;
                }

                f.lblTotal.Text = Convert.ToString(p.playerTotal);
            }

        }

        Card trueRandom(Deck d, Player p)
        {
            Random r = new Random();

            bool finding = true;
            Card search = new Card();
            while (finding == true)
            {
                search = d.deck[r.Next(0, d.deck.Count)];
                if (dealerInPlay.Contains(search) || p.playerInPlay.Contains(search))
                {
                    continue;
                }
                else
                {
                    finding = false;
                }
            }

            return search;
        }

    }
}
