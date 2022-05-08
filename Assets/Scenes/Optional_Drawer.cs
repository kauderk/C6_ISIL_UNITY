using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Editor
{
    [CustomPropertyDrawer(typeof(Optional_<>))]
    public class Optional_Drawer : PropertyDrawer
    {
        // suport for nested classes or structs
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valuePpt = property.FindPropertyRelative("value");
            return EditorGUI.GetPropertyHeight(property, label);
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var enabledPpt = property.FindPropertyRelative("enabled");
            var valuePpt = property.FindPropertyRelative("value");

            var ml = 24;
            // give margin-left...
            position.width -= ml;

            // wrap in group
            EditorGUI.BeginDisabledGroup(!enabledPpt.boolValue);
            EditorGUI.PropertyField(position, valuePpt, label, true); // ...to the label
            EditorGUI.EndDisabledGroup();

            // make square to
            position.x += position.width + ml;
            position.width = position.height = EditorGUI.GetPropertyHeight(enabledPpt);
            position.x -= position.width;

            // enable checkbox
            EditorGUI.PropertyField(position, enabledPpt, GUIContent.none);
        }
    }
}
#endif