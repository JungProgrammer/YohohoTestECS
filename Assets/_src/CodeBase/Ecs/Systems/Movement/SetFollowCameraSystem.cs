using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class SetFollowCameraSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<PlayerTag, GameObjectLink> _playerFilter;
        private EcsFilter<CameraTag>.Exclude<FollowData> _cameraFilter;

        public void Run()
        {
            if (_playerFilter.IsEmpty() || _cameraFilter.IsEmpty())
                return;


            foreach (int index in _cameraFilter)
            {
                EcsEntity cameraEntity = _cameraFilter.GetEntity(index);
                cameraEntity.Get<FollowData>() = new FollowData()
                {
                    Speed = _staticData.CameraSpeed,
                    Target = _playerFilter.Get2(0).Value.transform,
                    Offset = _staticData.CameraOffset
                };
            }
        }
    }
}