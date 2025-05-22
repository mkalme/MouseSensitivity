using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MouseSensitivity
{
    class Program
    {
        static int prevMouseY = 0;
        static int actualPixelsMovedY = 0;

        static void Main(string[] args)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X, 0);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                DateTime time1 = DateTime.Now;

                test();
                Debug.WriteLine((DateTime.Now - time1).TotalSeconds + " seconds");


            }).Start();

            int diff = 0;

            Random rand = new Random();

            while (true) {
                if (Cursor.Position.Y != prevMouseY){
                    diff = Cursor.Position.Y - prevMouseY;
                    actualPixelsMovedY += diff;

                    double newY = ((double)actualPixelsMovedY * 1.22);
                    int reminderPercentage = (int)((newY - (int)newY) * 100);

                    int randomNumber = rand.Next(100);
                    int addY = (randomNumber < reminderPercentage ? 1 : 0);

                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X, (int)newY + addY);
                    prevMouseY = Cursor.Position.Y;
                }
            }
        }

        static void test() {
            bool ifCont = true;
            while (ifCont) {
                Thread.Sleep(10);
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y + 1);
                ifCont = Cursor.Position.Y >= 1079 ? false : true;
            }
        }
    }
}
