using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.UnityBaseComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyMonoLink : MonoLink<RigidbodyLink>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Value.Value == null)
            {
                Value = new RigidbodyLink
                {
                    Value = GetComponent<Rigidbody>()
                };
            }
        }
#endif
    }
}