using System;
using System.Collections.Generic;
using System.Text;

namespace Vertices
{
    class Points
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public bool move { get; set; }
        public double value { get; set; }
       

        public Points(int x, int y, bool move)
        {
            this.xCoord = x;
            this.yCoord = y;
            this.move = move;
        }
        public Points(int x, int y)
        {
            this.xCoord = x;
            this.yCoord = y;
            
        }
        public Points() { }

        public override string ToString()
        {
            return "[" + xCoord + "]" + "[" + yCoord + "]";
            
        }
        public double PointValue(Points otherPoint)
        {
            int yValue = Math.Abs(yCoord - otherPoint.yCoord);
            int xValue = Math.Abs(xCoord - otherPoint.xCoord);
      
            double value = Math.Pow((double)xValue, 2.0) + Math.Pow((double)yValue, 2.0);
            return value = Math.Sqrt(value);
        }
   
        public bool isAPointOnList(List<Points> list)
        {
            bool isOnList = false;
            foreach(var item in list)
            {
                if ((item.xCoord == this.xCoord) && (item.yCoord == this.yCoord))
                {
                    isOnList = true;
                    break;
                }
            }
            return isOnList;
        }
        public bool NotOnList(List<Points> list)
        {
            bool isSafe = true;
            if (this.isAPointOnList(list))
            {
                isSafe = false;
            }
            return isSafe;
        }
      
    }
}
