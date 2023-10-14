using System;
using System.Collections.Generic;
using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.PlantLogic
{
    [Serializable]
    public struct GrowStagesLink
    {
        public int CurrentStage;
        public float DelayBetweenStages;
        public float CurrentDelayBetweenStages;
        public List<GameObject> StagesViews;
    }
}