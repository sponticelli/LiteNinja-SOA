using LiteNinja.Common.Editor;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  /*
  [CustomPropertyDrawer(typeof(ScriptableVariableBase), true)]
  public class SOVarPropertyDrawer : PropertyDrawer
  {
    private SerializedObject _serializedTargetObject;
    private readonly Color _bgColor = new Color(0.1f, 0.8352f, 1f, 1f);

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      EditorGUI.PropertyField(position, property, label);

      var targetObject = property.objectReferenceValue;
      if (targetObject == null)
        return;

      if (_serializedTargetObject == null || _serializedTargetObject.targetObject != targetObject)
      {
        _serializedTargetObject = new SerializedObject(targetObject);
      }

      property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, true);

      if (!property.isExpanded) return;
      
      EditorGUI.indentLevel++;
      var cacheBgColor = GUI.backgroundColor;
      GUI.backgroundColor = _bgColor;
      GUILayout.BeginVertical(GUI.skin.box);
      _serializedTargetObject.DrawInspectorExcept("m_Script");
      GUI.backgroundColor = cacheBgColor;
      GUILayout.EndVertical();
      EditorGUI.indentLevel--;
    }
    
    
  }
  
  */
}