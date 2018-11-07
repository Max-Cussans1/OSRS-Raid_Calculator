using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int capcounter = 0;
            string temppoints;
            string tempplayerpoints;
            double points;
            double playerpoints;
            double remainingpoints;

            //checks for input types at converts string appropriately i.e 60.2k -> 60200
            Console.WriteLine("Enter total Number of Points:");
            temppoints = Console.ReadLine();
            if (temppoints.Contains(",") == true)
            {
                temppoints = temppoints.Replace(",", String.Empty);
            }
            if ((temppoints.Contains("k") || temppoints.Contains("K") == true) && temppoints.Contains(".") == false)
            {
                temppoints = temppoints.Replace("k", "000");
                temppoints = temppoints.Replace("K", "000");
            }
            if (temppoints.Contains(".") == true && (temppoints.Contains("k") || temppoints.Contains("K") == true))
            {
                temppoints = temppoints.Replace(".", String.Empty);
                temppoints = temppoints.Replace("k", "00");
                temppoints = temppoints.Replace("K", "00");
            }


            Console.WriteLine("Enter your Number of Points:");
            tempplayerpoints = Console.ReadLine();
            if (tempplayerpoints.Contains(",") == true)
            {
                tempplayerpoints = tempplayerpoints.Replace(",", String.Empty);
            }
            if ((tempplayerpoints.Contains("k") || tempplayerpoints.Contains("K") == true) && tempplayerpoints.Contains(".") == false)
            {
                tempplayerpoints = tempplayerpoints.Replace("k", "000");
                tempplayerpoints = tempplayerpoints.Replace("K", "000");
            }
            if (tempplayerpoints.Contains(".") == true && (tempplayerpoints.Contains("k") || tempplayerpoints.Contains("K") == true))
            {
                tempplayerpoints = tempplayerpoints.Replace(".", String.Empty);
                tempplayerpoints = tempplayerpoints.Replace("k", "00");
                tempplayerpoints = tempplayerpoints.Replace("K", "00");
            }


            //convert input strings to ints
            points = Convert.ToInt32(temppoints);
            playerpoints = Convert.ToInt32(tempplayerpoints);
            remainingpoints = points;
            double extrachance;
            double itemchance = points / 7125;

            if(itemchance > 80)
            {
                itemchance = 80;
                //capcounter++;
            }

            double playerchance = itemchance * (playerpoints / points);
            double playerchancegroup = 100 *  (playerpoints / points);

            //Specific item chances stored in doubles
            double thrownaxechance = specificitemchance(itemchance, 5);
            double dexchance = specificitemchance(itemchance, 20);
            double dhcbowchance = specificitemchance(itemchance, 4);
            double anctopchance = specificitemchance(itemchance, 3);
            double tbowchance = specificitemchance(itemchance, 2);
            double tbowdroptable = specificitemchance(itemchance, 6);

            //Average kills needed for specific items stored in doubles
            double averagekillsitemstr = averagekills(itemchance);
            double averagekillsplayerstr = averagekills(playerchance);
            double averagekillsthrownaxe = averagekills(thrownaxechance);
            double averagekillsdex = averagekills(dexchance);
            double averagekillsdhcbow = averagekills(dhcbowchance);
            double averagekillsanctop = averagekills(anctopchance);
            double averagekillstbowstr = averagekills(tbowchance);
            double averagekillstbowdtable = averagekills(tbowdroptable);
        
            //output

            Console.WriteLine("\nChance of a first item for the team:  " + itemchance + "%  or  1/" + averagekillsitemstr + "\n");

            //Run a while loop to check if any more items can be dropped with higher points
            while (remainingpoints > 7125 * 80)
            {
                remainingpoints = remainingpoints - (7125 * 80);
                extrachance = remainingpoints / 7125;
                if(extrachance > 80)
                {
                    extrachance = 80;
                    //capcounter++;
                }
                double averagekillsextra = averagekills(extrachance);
                Console.WriteLine("Chance of another item for the team:  " + extrachance + "%  or  1/" + averagekillsextra + "\n");

            }

            Console.WriteLine("Chance of an item for you specifically:  " + playerchance + "%  or  1/" + averagekillsplayerstr + "\n");

            Console.WriteLine("Chance that if an item drops it is yours:  " + playerchancegroup + "%");

            Console.WriteLine("\nChance of thrownaxes:  " + thrownaxechance + "%  or  1/" + averagekillsthrownaxe + "\n");

            Console.WriteLine("Chance of a dex:  " + dexchance + "%  or  1/" + averagekillsdex + "\n");

            Console.WriteLine("Chance of a dragon hunter crossbow:  " + dhcbowchance + "%  or  1/" + averagekillsdhcbow + "\n");

            Console.WriteLine("Chance of ancestral top:  " + anctopchance + "%  or  1/" + averagekillsanctop + "\n");

            Console.WriteLine("Chance of hitting the twisted bow drop table:  " + tbowdroptable + "% or  1/" + averagekillstbowdtable + "\n");

            Console.WriteLine("Chance of a twisted bow:  " + tbowchance + "% or  1/" + averagekillstbowstr + "\n");

            Console.ReadLine();



            //Function to calculate how many kills on average it would take with current points using the percentage chance
            double averagekills(double itemchancef)
            {
                double result;
                result = 100 / itemchancef;
                return result;
            }

            //Function to calculate the percentage drop chances of specific items based off their weightings
            double specificitemchance(double generalitemchance, int weighting)
            {
                double result;
                result = generalitemchance / (100 / weighting);
                return result;
            }
        }
    }
}
