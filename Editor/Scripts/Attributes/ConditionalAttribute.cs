using UnityEngine;

namespace XaviEssencials
{
    public class ConditionalAttribute : PropertyAttribute
    {
        public string ConditionField;

        public ConditionalAttribute(string conditionField)
        {
            this.ConditionField = conditionField;
        }
    }
}
