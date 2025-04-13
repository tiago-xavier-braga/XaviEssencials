using UnityEngine;
using XaviEssencials.Shared;

namespace XaviEssencials.Runtime
{
    [CreateAssetMenu(fileName = "BoolEventChannel", menuName = "Xavi Essencials/BoolEventChannel")]
    public class BoolEventChannel : EventChannel<bool>
    {
        [field: SerializeField]
        [field: ReadOnly]
        public bool Value { get; private set; }

        public override void RaiseEvent(bool value)
        {
            Value = value;
            base.RaiseEvent(value);
        }
    }
}
