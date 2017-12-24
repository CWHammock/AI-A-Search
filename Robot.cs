using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vertices
{
    class Robot
    {
        public Points position { get; set; }
        public List<Points> history { get; set; }
        public List<Points> moveList { get; set; }

        public Robot(Points startingPoint)
        {
            this.position = new Points(startingPoint.xCoord, startingPoint.yCoord);
            this.history = new List<Points>();
            this.moveList = new List<Points>();
        }

        public void ShortestPathSearch(List<Points> list, Points end)
        {
            WriteToFile(">>>>>>>Shortest Path Search Map 1 <<<<<<<<<<");
            int counter = 0;
            moveList = list.ToList();
            while (true)
            {
                moveList = Calculations.ActionSPS(moveList, position);
                Points firstItem = new Points();
                firstItem = moveList.ElementAt(0);
                history.Add(firstItem);
                position.xCoord = firstItem.xCoord;
                position.yCoord = firstItem.yCoord;
                Console.WriteLine(firstItem.ToString());
                WriteToFile(firstItem.ToString());
                moveList.RemoveAt(0);
                counter++;
                if (firstItem.xCoord == end.xCoord && firstItem.yCoord == end.yCoord)
                {
                    Console.WriteLine("goal is reached in " + counter + " moves.");
                    WriteToFile("goal is reached in " + counter + " moves.");
                    return;
                }

            }
        }

        //starting prototype for online robot search
        public void MoveThruCourse(List<Points> list, Points start, Points end, int mapNumber)
        {
            WriteToFile(">>>>>>> Greedy best-first search for map " + mapNumber + "<<<<<<<<<<");
            int moves = 0;
            while(true)
            {
                Points upPoints = new Points((this.position.xCoord) - 1, this.position.yCoord);
                Points downPoints = new Points((this.position.xCoord) + 1, this.position.yCoord);
                Points rightPoints = new Points(this.position.xCoord, (this.position.yCoord) + 1);
                
                //give each point a value
                Console.WriteLine(upPoints.ToString());
                Console.WriteLine(downPoints.ToString());
                Console.WriteLine(rightPoints.ToString());

                var doubleList = new List<double>();
                double upPointsValue = (double)upPoints.PointValue(end);
                double downPointsValue = (double)downPoints.PointValue(end);
                double rightPointsValue = (double)rightPoints.PointValue(end);
                //check if move is on no contact list or a prior move (stops repeat evaluations)  there is a 
                //better way, however, with time contraints, I used this.
                if ((upPoints.NotOnList(list)) && (upPoints.NotOnList(moveList))) { doubleList.Add(upPointsValue); }
                if ((downPoints.NotOnList(list)) && (downPoints.NotOnList(moveList))) { doubleList.Add(downPointsValue); }
                if ((rightPoints.NotOnList(list)) && (rightPoints.NotOnList(moveList))) { doubleList.Add(rightPointsValue); }

                doubleList.Sort();
                //add to move history
                moveList.Add(position);
                WriteToFile("upValue: " + upPointsValue + " downValue: " + downPointsValue + " rightValue: " + rightPointsValue);
                WriteToFile("current position: " + position.ToString());

                if ((doubleList[0]) == rightPointsValue)
                {
                    MoveRight();
                }
                else if ((doubleList[0]) == downPointsValue)
                {
                    MoveDown();
                }
                else if ((doubleList[0]) == upPointsValue)
                {
                    MoveUp();
                }

                else { Console.WriteLine("I'm STUCK....HELP!!!!"); }

                if ((position.xCoord == end.xCoord) && (position.yCoord == end.yCoord))
                {
                    Console.WriteLine("Congrats. Goal reached!!!!!  \n" + 
                        "number of moves: " + moves);
                    WriteToFile("Congrats. Goal reached!!!!!  \n" +
                        "number of moves: " + moves);
                    return;
                }
                moves++; 
            }
            

        }
        public void MoveRight()
        {
            position.yCoord = position.yCoord + 1;
        }
        public void MoveUp()
        {
            position.xCoord = position.xCoord - 1; 
        }
        public void MoveDown()
        {
            position.xCoord = position.xCoord + 1;
        }

        public override string ToString()
        {
            return "current Postion: [" + position.xCoord + "][" + position.yCoord + "]";
        }
        public void WriteToFile(params string[] input)
        {
            File.AppendAllLines(@"C:\Users\Hammock\Desktop\Programming Assignments\Vertices\TestResults" + @"\testresults.txt.txt", input);
        }    
    
    }
}
