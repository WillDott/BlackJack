using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack.Items
{
    public abstract class Item
    {
        public PictureBox runtime;
        public string image;
        public string backImage;
        public int value;
        public bool flipped;

        public void flip()
        {
            if (flipped == true)
            {
                runtime.Image.Dispose();
                runtime.Image = null;
                runtime.Image = Image.FromFile(backImage);
                flipped = false;
            }
            else
            {
                runtime.Image.Dispose();
                runtime.Image = null;
                runtime.Image = Image.FromFile(image);
                flipped = true;
            }

        }

    }
}
