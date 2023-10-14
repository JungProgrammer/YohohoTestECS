using Leopotam.Ecs;
using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base
{
	[RequireComponent(typeof(MonoEntity))]
	public abstract class MonoLinkBase : MonoBehaviour
	{
		public abstract void Make(ref EcsEntity entity);
	}
}