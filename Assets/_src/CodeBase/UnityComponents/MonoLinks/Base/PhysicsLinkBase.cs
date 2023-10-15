using Leopotam.Ecs;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base
{
	public abstract class PhysicsLinkBase : MonoLinkBase
	{
		protected EcsEntity _entity;
		
		public override void Make(ref EcsEntity entity)
		{
			_entity = entity;
		}
	}
}