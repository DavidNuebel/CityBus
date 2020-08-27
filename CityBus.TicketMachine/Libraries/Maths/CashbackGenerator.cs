using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace CityBus.TicketMachine.Libraries.Maths
{
    public class CashbackGenerator
    {
        public static string[] title =  { "50€", "20€", "10€", "5€", "2€", "1€", "0,50€", "0,20€", "0,10€", "0,05€", "0,02€", "0,01€" };
        private static float[] multiplicator = { 50f, 20f, 10f, 5f, 2f, 1f, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };

        public static int[] Generate(float cash)
        {
            int[] count = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            float remainingcash = cash;
            for (int i = 0; i < count.Length; i++)
            {
                if (remainingcash >= 0)
                {
                    count[i] = (int)(remainingcash / multiplicator[i]);
                    remainingcash -= (count[i] * multiplicator[i]);
                }
            }

            return count;
        }
    }
}
