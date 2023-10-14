using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.PlayerInput;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Rotation
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<PlayerTag, RigidbodyLink, RotationInputData> _playerFilter;
        private EcsFilter<CameraTag, GameObjectLink> _cameraFilter;

        public void Run()
        {
            if (_playerFilter.IsEmpty() || _cameraFilter.IsEmpty())
                return;
            
            
            foreach (int index in _playerFilter)
            {
                ref RigidbodyLink rigidbodyLink = ref _playerFilter.Get2(index);
                ref RotationInputData rotationInputData = ref _playerFilter.Get3(index);
                
                if (rotationInputData.Direction == Vector3.zero)
                    continue;
                

                GameObjectLink cameraGameObjectLink = _cameraFilter.Get2(0);

                Vector3 rotationDirection = cameraGameObjectLink.Value.transform.TransformDirection(rotationInputData.Direction);
                rotationDirection.y = 0;

                Rotate(rotationDirection, rigidbodyLink);
            }
        }

        private void Rotate(Vector3 rotationDirection, RigidbodyLink rigidbodyLink)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            rigidbodyLink.Value.MoveRotation(
                Quaternion.Lerp(
                    rigidbodyLink.Value.rotation,
                    targetRotation,
                    _staticData.HeroRotationSpeed * Time.deltaTime
                )
            );
        }
    }
}