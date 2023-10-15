using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags.Plants;
using YohohoTest._src.CodeBase.Ecs.Components.PlantLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.PlantsControlling
{
    public class GrowSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<GrowStagesLink>.Exclude<GrowCompletedTag> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref GrowStagesLink growStagesLink = ref _filter.Get1(index);

                growStagesLink.CurrentDelayBetweenStages += Time.deltaTime;
                if (growStagesLink.CurrentDelayBetweenStages < growStagesLink.DelayBetweenStages)
                    continue;


                growStagesLink.CurrentDelayBetweenStages = 0;
                
                IncreaseStageIndex(ref growStagesLink);
                ActivateSecondStageView(ref growStagesLink);

                _world.NewEntity().Get<PlantChangedStageEvent>() = new PlantChangedStageEvent()
                {
                    PlantEntity = _filter.GetEntity(index)
                };

                if (growStagesLink.CurrentStage == growStagesLink.StagesViews.Count - 1)
                    _filter.GetEntity(index).Get<GrowCompletedTag>() = new GrowCompletedTag();
            }
        }

        private void IncreaseStageIndex(ref GrowStagesLink growStagesLink)
        {
            growStagesLink.CurrentDelayBetweenStages = 0;
            growStagesLink.CurrentStage++;
            growStagesLink.CurrentStage = Mathf.Clamp(growStagesLink.CurrentStage, 0, growStagesLink.StagesViews.Count - 1);
        }

        private void ActivateSecondStageView(ref GrowStagesLink growStagesLink)
        {
            foreach (GameObject stagesView in growStagesLink.StagesViews) 
                stagesView.SetActive(false);

            growStagesLink.StagesViews[growStagesLink.CurrentStage].gameObject.SetActive(true);
        }
    }
}