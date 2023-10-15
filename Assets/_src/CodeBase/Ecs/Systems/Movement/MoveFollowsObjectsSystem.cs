using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class MoveFollowsObjectsSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<FollowData, GameObjectLink> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref FollowData followData = ref _filter.Get1(index);
                ref GameObjectLink gameObjectLink = ref _filter.Get2(index);

                gameObjectLink.Value.transform.position = Vector3.SmoothDamp(
                    gameObjectLink.Value.transform.position,
                    followData.Target.position + followData.Offset,
                    ref followData.CurrentVelocity,
                    followData.Speed);
            }
        }
    }
}