using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.UnityBaseComponents
{
    public class GameObjectMonoLink : MonoLink<GameObjectLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<GameObjectLink>() = new GameObjectLink
            {
                Value = gameObject
            };
        }
    }
}