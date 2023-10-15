using Leopotam.Ecs;

namespace YohohoTest._src.CodeBase.Ecs.Components.StackLogic
{
    public struct StackRemovingToStock
    {
        public EcsEntity StockEntity;
        public float RemoveDelay;
        public float CurrentRemoveDelay;
    }
}