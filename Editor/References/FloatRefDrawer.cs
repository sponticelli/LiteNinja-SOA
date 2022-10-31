using LiteNinja.SOA.References;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  [CustomPropertyDrawer(typeof(FloatRef))]
  public class FloatRefDrawer : PropertyDrawer
  {
    private readonly string[] popupOptions = {"Use Local", "Use Variable"};
    private GUIStyle popupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
      {
        imagePosition = ImagePosition.ImageOnly
      };

      label = EditorGUI.BeginProperty(position, label, property);
      position = EditorGUI.PrefixLabel(position , label);

      EditorGUI.BeginChangeCheck();
            
      var useLocal = property.FindPropertyRelative("UseLocal");
      var localValue = property.FindPropertyRelative("LocalValue");
      var variable = property.FindPropertyRelative("Variable");
            
      var buttonRect = new Rect(position);
      buttonRect.yMin += popupStyle.margin.top;
      buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
      position.xMin = buttonRect.xMax + 15;
            
      var indent = EditorGUI.indentLevel;
      EditorGUI.indentLevel = 0;

      var result = EditorGUI.Popup(buttonRect, useLocal.boolValue ? 0 : 1, popupOptions, popupStyle);

      useLocal.boolValue = result == 0;

      EditorGUI.PropertyField(position,
        useLocal.boolValue ? localValue : variable,
        GUIContent.none);

      if (EditorGUI.EndChangeCheck())
        property.serializedObject.ApplyModifiedProperties();

      EditorGUI.indentLevel = indent;
      EditorGUI.EndProperty();
    }
  }
}