using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base
{
	public class MonoEntity : MonoLinkBase
	{
		private EcsEntity _entity;
        
		private MonoLinkBase[] _monoLinks;

		public MonoLink<T> Get<T>() where T: struct
		{
			foreach (MonoLinkBase link in _monoLinks)
			{
				if (link is MonoLink<T> monoLink)
				{
					return monoLink;
				}
			}

			return null;
		}
        
		public override void Make(ref EcsEntity entity)
		{
			_entity = entity;
            
			_monoLinks = GetComponents<MonoLinkBase>();
			foreach (MonoLinkBase monoLink in _monoLinks)
			{
				if (monoLink is MonoEntity)
					continue;
				
				monoLink.Make(ref entity);
			}

			entity.Get<GameObjectLink>() = new GameObjectLink {Value = gameObject};
			entity.Get<Position>() = new Position {Value = transform.position};
		}
	}
}