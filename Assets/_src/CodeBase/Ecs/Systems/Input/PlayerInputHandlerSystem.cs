using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.PlayerInput;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Input
{
    public class PlayerInputHandlerSystem : IEcsRunSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private EcsFilter<PlayerTag, MovementInputData> _movementFilter;
        private EcsFilter<PlayerTag, RotationInputData> _rotationFilter;

        public void Run()
        {
            foreach (int index in _movementFilter)
            {
                ref MovementInputData movementInputData = ref _movementFilter.Get2(index);
                movementInputData.Direction = new Vector3(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical), 0).normalized;
            }

            foreach (int index in _rotationFilter)
            {
                ref RotationInputData rotationInputData = ref _rotationFilter.Get2(index);
                rotationInputData.Direction = new Vector3(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical), 0).normalized;
            }
        }
    }
}