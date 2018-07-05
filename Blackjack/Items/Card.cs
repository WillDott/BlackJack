using Blackjack.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public class Card : Item
    {
        public string name;

        public int valueCalculator(string value)
        {
            int result;

            if (value.Length == 7)
            {
                return 10;
            }
            else
            {
                if (int.TryParse(value, out result) != true)
                {
                    if (value.Substring(0, 1) == "A") //Needs sorting etither 1 or 11
                    {
                        result = 11;
                        return result;
                    }
                    else if (value.Substring(0, 1) == "J" || value.Substring(0, 1) == "K" || value.Substring(0, 1) == "Q")
                    {
                        result = 10;
                        return result;
                    }
                }
                result = Convert.ToInt32(value.Substring(0, 1));
                return result;
            }
        }



        

        
    }

    
}
