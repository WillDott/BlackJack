using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> deck = new List<Card>();

        public void createDeck(Form1 f)
        {
            while (deck.Count < 51)
            {
                foreach (string s in Directory.GetFiles("JPEG", "*.jpg").Select(Path.GetFileName))
                {
                    Card c = new Card();
                    c.name = s;
                    c.image = "JPEG/" + s;
                    c.backImage = "JPEG/back/back.jpg";
                    c.value = c.valueCalculator(s);
                    c.flipped = false;

                    PictureBox picture = new PictureBox
                    {
                        Name = c.name,
                        Size = new Size(69, 106),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(c.backImage),

                    };

                    picture.Click += new EventHandler(f.handlePCTClick);

                    c.runtime = picture;

                    deck.Add(c);
                }
            }
            shuffleDeck();
        }

        public void shuffleDeck()
        {
            Random r = new Random();

            deck = sorting.MergeSort(deck, 0, deck.Count - 1);
            deck.OrderBy(a => r.Next());
        }

        public void flipAll(bool showValue)
        {
            foreach(Card c in deck)
            {
                if (showValue == true)
                {
                    c.runtime.Image.Dispose();
                    c.runtime.Image = null;
                    c.runtime.Image = Image.FromFile(c.backImage);
                    c.flipped = false;
                }
                else
                {
                    c.runtime.Image.Dispose();
                    c.runtime.Image = null;
                    c.runtime.Image = Image.FromFile(c.image);
                    c.flipped = true;
                }
            }
            

            foreach(Card c in deck)
            {
                c.flip();
            }
        }


    }
}
