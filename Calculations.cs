using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vertices
{
    static class Calculations
    {
        //takes in a list and sorts list by value property of Points objects
        public static List<Points> OptimalPath(List<Points> list)
        {
            List<Points> optimalPath = new List<Points>();
            optimalPath = list.ToList();
            optimalPath = optimalPath.Cast<Points>().OrderBy(x => x.value).ToList();
            return optimalPath;
        }

        //prints points objects properties from a list in format
        public static void ToStringList(List<Points> optimalPath)
        {
            int index = 1;

            foreach (Points item in optimalPath)
            {
                Console.Write(index + ". ");
                Console.WriteLine("coords: [" + item.xCoord + "][" + item.yCoord + "]");
                Console.WriteLine("safe to move: " + item.move);
                index++;
                
            }
        }
        //gives a list of verticies from closest to furthest from point object for ShortestPathSearch
        public static List<Points> ActionSPS(List<Points> list, Points Point)
        { 
            //adds value property to each Points object in list
            foreach (Points item in list)
            {
                double itemValueStart = item.PointValue(Point);
                item.value = itemValueStart;
            }
            list = OptimalPath(list);
            return list;

        }
        
    }
}
