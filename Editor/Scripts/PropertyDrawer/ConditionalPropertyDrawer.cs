using UnityEditor;
using UnityEngine;

namespace XaviEssencials
{
    [CustomPropertyDrawer(typeof(ConditionalAttribute))]
    public class ConditionalPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditional = (ConditionalAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionField);

            if (conditionProperty != null && conditionProperty.propertyType == SerializedPropertyType.Boolean)
            {
                if (conditionProperty.boolValue)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }
            else
            {
                Debug.LogWarning($"[ConditionalPropertyDrawer] The parameter '{conditional.ConditionField}' not found or not is boolean");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditional = (ConditionalAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionField);

            if (conditionProperty != null && conditionProperty.propertyType == SerializedPropertyType.Boolean)
            {
                return conditionProperty.boolValue ? EditorGUI.GetPropertyHeight(property, label) : 0;
            }
            return EditorGUI.GetPropertyHeight(property, label);
        }
    }
}
