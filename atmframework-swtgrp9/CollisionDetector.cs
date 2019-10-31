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

        const int VerticalMax = 300;
        const int HorizontalMax = 5000;

        public CollisionDetector(ILog log)
        {
            _log = log;
            _conditionList = new List<SeparationCondition>();
        }

        public List<SeparationCondition> GetConditions()
        {
            return _conditionList;
        }

        private bool PlaneCollision(IAirplaneInfo plane1, IAirplaneInfo plane2)
        {

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
