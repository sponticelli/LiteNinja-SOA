using System;
using LiteNinja.SOA.Variables;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  [CustomEditor(typeof(BindComparisonToUnityEvent))]
  [CanEditMultipleObjects]
  public class BindComparisonToUnityEventDrawer : UnityEditor.Editor
  {
    private BindComparisonToUnityEvent _targetScript;

    private SerializedProperty _boolVariable;
    private SerializedProperty _boolVariableComparer;

    SerializedProperty _intReference;
    SerializedProperty _intReferenceComparer;

    SerializedProperty _floatReference;
    SerializedProperty _floatReferenceComparer;


    SerializedProperty _stringReference;
    SerializedProperty _stringReferenceComparer;

    SerializedProperty _unityEvent;

    private void OnEnable()
    {
      _targetScript = (BindComparisonToUnityEvent)target;
      _boolVariable = serializedObject.FindProperty("boolVariable");
      _boolVariableComparer = serializedObject.FindProperty("boolVariableComparer");

      _intReference = serializedObject.FindProperty("intReference");
      _intReferenceComparer = serializedObject.FindProperty("intReferenceComparer");

      _floatReference = serializedObject.FindProperty("floatReference");
      _floatReferenceComparer = serializedObject.FindProperty("floatReferenceComparer");

      _stringReference = serializedObject.FindProperty("stringReference");
      _stringReferenceComparer = serializedObject.FindProperty("stringReferenceComparer");

      _unityEvent = serializedObject.FindProperty("_unityEvent");
    }

    public override void OnInspectorGUI()
    {
      _targetScript.Type = (CustomVariableType)EditorGUILayout.EnumPopup("Variable Type", _targetScript.Type);

      switch (_targetScript.Type)
      {
        case CustomVariableType.NONE:
          break;
        case CustomVariableType.BOOL:
          EditorGUILayout.PropertyField(_boolVariable, new GUIContent("Bool Variable"));
          EditorGUILayout.PropertyField(_boolVariableComparer, new GUIContent("Bool Comparer"));
          EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
          break;
        case CustomVariableType.INT:
          EditorGUILayout.PropertyField(_intReference, new GUIContent("Int Reference"));
          _targetScript.operation =
            (BindComparisonToUnityEvent.Operation)EditorGUILayout.EnumPopup("Operation",
              _targetScript.operation);
          EditorGUILayout.PropertyField(_intReferenceComparer, new GUIContent("Int Reference Comparer"));
          EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
          break;
        case CustomVariableType.FLOAT:
          EditorGUILayout.PropertyField(_floatReference, new GUIContent("Float Reference"));
          _targetScript.operation =
            (BindComparisonToUnityEvent.Operation)EditorGUILayout.EnumPopup("Operation",
              _targetScript.operation);
          EditorGUILayout.PropertyField(_floatReferenceComparer, new GUIContent("Float Reference Comparer"));
          EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
          break;
        case CustomVariableType.STRING:
          EditorGUILayout.PropertyField(_stringReference, new GUIContent("String Reference"));
          EditorGUILayout.PropertyField(_stringReferenceComparer, new GUIContent("String Reference Comparer"));
          EditorGUILayout.PropertyField(_unityEvent, new GUIContent("Event"));
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      serializedObject.ApplyModifiedProperties();
    }
  }
}