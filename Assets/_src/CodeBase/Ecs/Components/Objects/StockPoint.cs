using System;
using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Objects
{
    [Serializable]
    public struct StockPoint
    {
        public Transform Point;
        public int NumbersOfItemsAtRow;
        public float DistanceBetweenItems;
    }
}