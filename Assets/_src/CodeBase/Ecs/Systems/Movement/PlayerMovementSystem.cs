using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.PlayerInput;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<PlayerTag, RigidbodyLink, MovementInputData> _playerFilter;
        private EcsFilter<CameraTag, GameObjectLink> _cameraFilter;
        
        public void Run()
        {
            if (_playerFilter.IsEmpty() || _cameraFilter.IsEmpty())
                return;


            foreach (int index in _playerFilter)
            {
                ref RigidbodyLink rigidbodyLink = ref _playerFilter.Get2(index);
                ref MovementInputData movementInputData = ref _playerFilter.Get3(index);

                GameObjectLink cameraGameObjectLink = _cameraFilter.Get2(0);

                Vector3 movementDirection = cameraGameObjectLink.Value.transform.TransformDirection(movementInputData.Direction);
                movementDirection.y = 0;

                rigidbodyLink.Value.velocity = movementDirection.normalized * _staticData.HeroMovementSpeed;
            }
        }
    }
}