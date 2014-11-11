using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiTProject
{
    public static class Extensions
    {
        public static bool Contains(this int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return true;
            }

            return false;
        }

        public static Boolean[,] Copy(this Boolean[,] array, int rows, int cols)
        {
            Boolean[,] ret = new Boolean[cols,rows];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    ret[r, c] = array[r, c];
            
            return ret;
        }
    }
}
