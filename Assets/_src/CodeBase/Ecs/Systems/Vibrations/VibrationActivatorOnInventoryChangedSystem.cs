using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Services.Vibration;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Vibrations
{
    public class VibrationActivatorOnInventoryChangedSystem : IEcsRunSystem
    {
        private IVibrationService _vibrationService;
        private EcsFilter<HandItemsCountChangedEvent> _filter;
        
        public void Run()
        {
            if (_filter.IsEmpty())
                return;
            
            
            _vibrationService.PlayLightImpact();
        }
    }
}