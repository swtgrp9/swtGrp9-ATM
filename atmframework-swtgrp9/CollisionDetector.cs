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
            for (int i = 0; i < compareList.Count; i++)
            {
                for (int j = 0; j < compareList.Count; j++)
                {
                    IAirplaneInfo plane1 = compareList[i];
                    IAirplaneInfo plane2 = compareList[j];

                }
            }
        }
    }
}
