using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base;

namespace UnityComponents.MonoLinks.PhysicsLinks
{
	public class OnTriggerEnterMonoLink : PhysicsLinkBase
	{
		private void OnTriggerEnter(Collider other)
		{
			_entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent()
			{
				Collider = other,
				Sender = gameObject
			};
		}
	}
}