using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    class CollisionDetector : ICollisionDetector
    {
        private ILog _log;
        private List<SeparationCondition> _conditionList;

        private const int VerticalMax = 300;
        private const int HorizontalMax = 5000;

        public CollisionDetector(ILog log)
        {
            _log = log;
            _conditionList = new List<SeparationCondition>();
        }

        public List<SeparationCondition> GetConditions()
        {
            return _conditionList;
        }

        //Returns true if the separation of the planes drops below the specified threshold in both vertical and horizontal
        private bool PlaneCollision(IAirplaneInfo plane1, IAirplaneInfo plane2)
        {
            double xDiff = (Math.Pow(Math.Abs(plane1.X - plane2.X), 2));
            double yDiff = (Math.Pow(Math.Abs(plane1.Y - plane2.Y), 2));

            double horizontalDist = Math.Sqrt(xDiff - yDiff);

            double verticalDist = Math.Abs(plane1.Altitude - plane2.Altitude);

            if ((verticalDist < VerticalMax) && (horizontalDist < HorizontalMax) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Register(List<IAirplaneInfo> compareList)
        {
            for (var i = 0; i < compareList.Count; i++)
            {
                for (var j = 0; j < compareList.Count; j++)
                {
                    
                    IAirplaneInfo plane1 = compareList[i];
                    IAirplaneInfo plane2 = compareList[j];
                    var newestplanetime = DateTime.Compare(plane1.TimeStamp, plane2.TimeStamp) < 0
                        ? plane1.TimeStamp
                        : plane2.TimeStamp;

                    Tuple<IAirplaneInfo, IAirplaneInfo> temptTuple = new Tuple<IAirplaneInfo, IAirplaneInfo>(plane1, plane2);
                    SeparationCondition tempCondition = new SeparationCondition(newestplanetime, temptTuple);

                    if (PlaneCollision(plane1, plane2)) //If collision imminent, check if already logged - if not then add it
                    {
                        var alreadyLogged = false;
                        for (var k = 0; k < _conditionList.Count; k++)
                        {
                            if (tempCondition.EqualCondition(_conditionList[k]))
                            {
                                alreadyLogged = true;
                            }
                        }

                        if (alreadyLogged == false)
                        {
                            _log.Logs(LOGTYPE.COLLISIONS, new List<string>()
                            {
                                "Time: " + tempCondition.Time + " Tag plane 1: " + tempCondition.PairAirplanes.Item1.Tag + " Tag plane 2: " + tempCondition.PairAirplanes.Item2.Tag
                            });

                            _conditionList.Add(tempCondition);
                        }
                    }
                    else if (!PlaneCollision(plane1, plane2)) //Removes condition from list if not colliding 
                    {
                        for (var k = 0; k < _conditionList.Count; k++)
                        {
                            if (tempCondition.EqualCondition(_conditionList[k]))
                            {
                                _conditionList.Remove(_conditionList[k]);
                            }
                            
                        }
                    }

                }
            }
        }
    }
}
