using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement.GlobalMovers
{
    public class MovementObjectsWithMovementDataSystem : IEcsRunSystem
    {
        private EcsFilter<MovementData> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref MovementData movementData = ref _filter.Get1(index);
                movementData.MovementTransform.position += movementData.MovementSpeed * 
                                                           Time.deltaTime * 
                                                           (movementData.TargetPosition - movementData.MovementTransform.position).normalized;

                if (Vector3.Distance(movementData.MovementTransform.position, movementData.TargetPosition) >= movementData.MaxOffsetDistance)
                    continue;
                
                
                _filter.GetEntity(index).Del<MovementData>();
            }
        }
    }
}