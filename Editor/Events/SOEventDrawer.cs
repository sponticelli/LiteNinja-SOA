using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  [CustomEditor(typeof(ScriptableEventBase), true)]
  public class SOEventDrawer : UnityEditor.Editor
  {
    private MethodInfo _methodInfo;

    private void OnEnable()
    {
      _methodInfo = target.GetType().BaseType.GetMethod("Raise",
        BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
    }

    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();

      if (GUILayout.Button("Raise"))
      {
        var property = serializedObject.FindProperty("_debugValue");
        _methodInfo.Invoke(target, new object[] { GetDebugValue(property) });
      }

      if (!EditorApplication.isPlaying) return;

      Common.Editor.EditorUtils.DrawLine();

      var goContainer = (IDrawObjectsInInspector)target;
      var gameObjects = goContainer.GetAllObjects();

      if (gameObjects.Count > 0) DisplayAll(gameObjects);
    }

    private static void DisplayAll(List<Object> objects)
    {
      GUILayout.Space(15);
      var title = $"Listener Amount : {objects.Count}";
      GUILayout.BeginVertical(title, "window");
      foreach (var obj in objects)
      {
        Common.Editor.EditorUtils.DisplayObject(obj, new[] { obj.name, "Select" });
      }

      GUILayout.EndVertical();
    }

    private object GetDebugValue(SerializedProperty property)
    {
      var targetType = property.serializedObject.targetObject.GetType();
      var targetField = targetType.GetField("_debugValue", BindingFlags.Instance | BindingFlags.NonPublic);
      return targetField.GetValue(property.serializedObject.targetObject);
    }
  }
}