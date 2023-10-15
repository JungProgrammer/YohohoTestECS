using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.PlantsControlling
{
    public class PlayPunchAnimationDuringPlantGrowingSystem : IEcsRunSystem
    {
        private EcsFilter<PlantChangedStageEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref GameObjectLink plantGameObjectLink = ref _filter.Get1(index).PlantEntity.Get<GameObjectLink>();

                PlayPunchAnimation(plantGameObjectLink);
            }
        }

        private static void PlayPunchAnimation(GameObjectLink plantGameObjectLink)
        {
            DOTween.Kill(plantGameObjectLink.Value.transform);
            plantGameObjectLink.Value.transform.DOPunchScale(Vector3.one * .7f, .3f, 4);
        }
    }
}