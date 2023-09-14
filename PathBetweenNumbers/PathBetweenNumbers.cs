using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class PathBetweenNumbers
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given two numbers X and Y, find the min number of operations to convert X into Y
        /// Allowed Operations:
        /// 1.	Multiply the current number by 2 (i.e. replace the number X by 2 × X)
        /// 2.	Subtract 1 from the current number (i.e. replace the number X by X – 1)
        /// 3.	Append the digit 1 to the right of current number (i.e. replace the number X by 10 × X + 1).
        /// </summary>
        /// <param name="X">start number</param>
        /// <param name="Y">target number</param>
        /// <returns>min number of operations to convert X into Y</returns>
        public static int Find(int X, int Y)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            // If both are equal then return 0
            if (X == Y)
            {
                return 0;
            }
            else
            {
                Queue<int> myQ = new Queue<int>();
                Dictionary<int, int> myD = new Dictionary<int, int>();
                myD.Add(X, 0);
                int myQ_Top = X;
                myQ.Enqueue(X);
                while (myQ.Count!=0)
                {
                    myQ_Top= myQ.Peek();
                    myQ.Dequeue();
                    if (myQ_Top == Y)
                    {
                        return myD[myQ_Top];
                    }

                    if (!myD.ContainsKey(myQ_Top * 2) && Y + 1 >= myQ_Top * 2) 
                    {
                        myD[myQ_Top * 2] = myD[myQ_Top] + 1;
                        myQ.Enqueue(myQ_Top * 2);
                    }
                    if (!myD.ContainsKey(myQ_Top - 1) && (Y >= myQ_Top - 1 || myQ_Top - 1 <= 500) && myQ_Top - 1 > 0) 
                    {
                        myD[myQ_Top - 1] = myD[myQ_Top] + 1;
                        myQ.Enqueue(myQ_Top - 1);
                    }
                    if (!myD.ContainsKey(10 * myQ_Top + 1) && Y + 1 >= 10 * myQ_Top + 1) 
                    {
                        myD[10 * myQ_Top + 1] = myD[myQ_Top] + 1;
                        myQ.Enqueue(10 * myQ_Top + 1);
                    }
                }
                return -1;
            }
        }
        #endregion

    }
}
