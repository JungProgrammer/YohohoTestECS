using Leopotam.Ecs;

namespace YohohoTest._src.CodeBase.Ecs.Components.Objects
{
    public struct SpawnerEntity
    {
        public EcsEntity Value;

        public SpawnerEntity(EcsEntity value)
        {
            Value = value;
        }
    }
}