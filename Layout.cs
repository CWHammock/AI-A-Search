using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vertices
{
    
    class Layout
    {

        public List<Points> verticies { get; set; }
        public List<Points> noTravel { get; private set; }
        public Points start { get; private set; }
        public Points end { get; private set; }
        
        
        //constructor
        public Layout(int[,] map)
        {
            this.verticies = new List<Points>();
            for (int i = 0; i < ((map.GetLength(0) - 1)); i++)
            {
                for (int x = 0; x < (map.GetLength(1)); x++)
                {
                    if (map[i,x] == 3 || map[i, x] == 5) { verticies.Add(new Points(i, x)); }
                    if (map[i, x] == 2) { this.start = new Points(i, x); }
                    if (map[i, x] == 5){ this.end = new Points(i, x); }
                    

                }
               
            }
        }
        //constructor
        public Layout(int[,] map, int type)
        {
            this.verticies = new List<Points>();
            this.noTravel = new List<Points>();
            for (int i = 0; i < ((map.GetLength(0) - 1)); i++)
            {
                for (int x = 0; x < (map.GetLength(1)); x++)
                {
                    if (map[i, x] == 3) { verticies.Add(new Points(i, x)); }
                    if (map[i, x] == 2) { this.start = new Points(i, x); }
                    if (map[i, x] == 5) { this.end = new Points(i, x); }
                    if (map[i, x] == 1 || map[i, x] == 9 || map[i, x] == 3) { noTravel.Add(new Points(i, x)); }
                }

            }
        }
    }
}
