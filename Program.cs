using System;
using System.Collections.Generic;
using System.IO;

namespace Vertices
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] mapArray = MapImport.getArray();
            Layout newProblem = new Layout(mapArray);
            Robot robot = new Robot(newProblem.start);

            robot.ShortestPathSearch(newProblem.verticies, newProblem.end);

            Console.ReadKey();
        }
    }

}
