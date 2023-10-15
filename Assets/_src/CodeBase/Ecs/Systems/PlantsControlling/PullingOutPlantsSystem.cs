using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags.Plants;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Tags;

namespace YohohoTest._src.CodeBase.Ecs.Systems.PlantsControlling
{
    public class PullingOutPlantsSystem : IEcsRunSystem
    {
        private EcsFilter<PlantTag, GrowCompletedTag, OnTriggerEnterEvent>.Exclude<PlantPulledOutEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                OnTriggerEnterEvent onTriggerEnterEvent = _filter.Get3(index);

                if (!onTriggerEnterEvent.Collider.TryGetComponent(out PlayerTagMonoLink playerTagMonoLink))
                    continue;


                EcsEntity plant = _filter.GetEntity(index);
                plant.Get<PlantPulledOutEvent>() = new PlantPulledOutEvent();
                plant.Get<DeactivateColliderEvent>() = new DeactivateColliderEvent();
            }
        }
    }
}