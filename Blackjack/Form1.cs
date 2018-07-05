using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Dealer dealer = new Dealer();
        Deck deck = new Deck();
        Player player = new Player();
        int tableValue = 0;
   
        public Form1()
        {
            InitializeComponent();
            deck.createDeck(this);
            beginGame();
        }

        void beginGame()
        {
            clearTable();
            deck.flipAll(false);
            player.playerTotal = 0;
            dealer.dealerTotal = 0;
            dealer.dealCards(2, 2, player, this, deck);
            if(player.playerTotal == 21 || dealer.dealerTotal == 21) { MessageBox.Show("BlackJack!!!"); whoWon(); }
        }

        private void clearTable()
        {
            int i = 0;
            while (i < Controls.Count)
            {
                Control c = Controls[i];

                if (c is PictureBox)
                {
                    PictureBox pbox = c as PictureBox;
                    Controls.Remove(c);
                }
                else
                {
                    i++;
                }
            }

            deck.flipAll(false);
            player.playerInPlay.Clear();
            dealer.dealerInPlay.Clear();
        }

        public void addcard(Card c, Point location)
        {
            c.runtime.Location = location;
            Controls.Add(c.runtime);
            
        }

        public void addchip(Chip c, Point location)
        {
            c.runtime.Location = location;
            Controls.Add(c.runtime);
        }

        public void whoWon()
        {
            if(dealer.dealerTotal > 21 && player.playerTotal > 21)
            {
                MessageBox.Show("Draw!");
            }
            else if(dealer.dealerTotal  > 21)
            {
                MessageBox.Show("You win!");
            }
            else if(player.playerTotal > 21)
            {
                MessageBox.Show("Dealer wins!");
            }
            else
            {
                if((dealer.dealerTotal > player.playerTotal))
                {
                    MessageBox.Show("Dealer wins!");
                }
                else if (player.playerTotal > dealer.dealerTotal)
                {
                    MessageBox.Show("You win!");
                }
                else if (player.playerTotal == dealer.dealerTotal)
                {
                    MessageBox.Show("Draw!");
                }
            }

            beginGame();
        }

       public void handlePCTClick(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;

            foreach(Card c in player.playerInPlay)
            {
              if (c.runtime.Name == p.Name)
                {
                    c.flip();
                }
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if(player.playerTotal < 22)
            {
                dealer.dealCards(0, 1, player, this, deck);
            }
            else
            {
                dealer.dealerPlay(player, this, deck);
            }
            
        }

        private void btnStick_Click(object sender, EventArgs e)
        {
            dealer.dealerPlay(player, this, deck);
        }
    }
}
