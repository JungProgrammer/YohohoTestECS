using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.UI
{
    public class UpdateInventoryUISystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        
        private EcsFilter<HandItemTag, StackPlace>.Exclude<RemovedFromStackTag> _stackFilter;
        private EcsFilter<HandItemsCountChangedEvent> _eventFilter;
            
        public void Run()
        {
            foreach (int index in _eventFilter)
            {
                _sceneData.HeadUpDisplay.InventoryPanel.UpdateItemsCount(_stackFilter.GetEntitiesCount());
            }
        }
    }
}