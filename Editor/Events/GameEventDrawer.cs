using System.Collections.Generic;
using LiteNinja.SOA.Events;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  [CustomEditor(typeof(GameEvent))]
  public class GameEventDrawer : UnityEditor.Editor
  {
    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();

      if (GUILayout.Button("Raise"))
      {
        var eventNoParam = (GameEvent)target;
        eventNoParam.Raise();
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
      var title = $"# Listeners : {objects.Count}";
      GUILayout.BeginVertical(title, "window");
      foreach (var obj in objects)
      {
        Common.Editor.EditorUtils.DisplayObject(obj, new[] { obj.name, "Select" });
      }

      GUILayout.EndVertical();
    }
  }
}