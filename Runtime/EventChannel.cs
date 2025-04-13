using UnityEngine;
using UnityEngine.Events;
using XaviEssencials.Shared;

namespace XaviEssencials.Runtime
{
    public class EventChannel<T> : ScriptableObject
    {
        public UnityAction<T> OnEventRaised;

        public virtual void RaiseEvent(T value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
