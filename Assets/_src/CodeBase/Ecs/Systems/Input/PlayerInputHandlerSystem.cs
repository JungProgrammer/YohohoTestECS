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

        private EcsFilter<PlayerTag, MovementInputData> _filter;

        public void Run()
        {
            if (_filter.IsEmpty())
                return;


            foreach (int index in _filter)
            {
                ref MovementInputData movementInputData = ref _filter.Get2(index);
                movementInputData.Direction = new Vector3(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical), 0).normalized;
            }
        }
    }
}