using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class sorting
    {

        public static List<Card> MergeSort(List<Card> list, int start, int end)
        {
            int mid = 0;
            List<Card> l1;
            List<Card> l2;
            List<Card> append = new List<Card>();

            if (start < end)
            {
                mid = (start + end) / 2;
                l1 = MergeSort(list, start, mid);
                l2 = MergeSort(list, mid + 1, end);
                return Merge(l1, l2);
            }
            else
            {
                append.Add(list[start]);
                return append;
            }
        }

        static List<Card> Merge(List<Card> l1, List<Card>l2)
        {
            List<Card> returnList = new List<Card>();
            int l1Index = 0, l2Index = 0;

            while (returnList.Count != l1.Count+ l2.Count)
            {
                if(l2Index == l2.Count || (l1Index < l1.Count && l1[l1Index].value <= l2[l2Index].value))
                {
                    returnList.Add(l1[l1Index]);
                    l1Index++;
                }
                else if(l1Index == l1.Count || (l2Index < l2.Count && l2[l2Index].value <= l1[l1Index].value))
                {
                    returnList.Add(l2[l2Index]);
                    l2Index++;
                }
            }

            return returnList;

        }
    }
}
