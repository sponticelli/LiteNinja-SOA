using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{
  [CustomEditor(typeof(ScriptableListBase), true)] 
  public class SOListEditorDrawer : UnityEditor.Editor
  {
    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();
      if (!EditorApplication.isPlaying) return;
      var container = (IDrawObjectsInInspector) target;
      var gameObjects = container.GetAllObjects();

      Common.Editor.EditorUtils.DrawLine();
      if (gameObjects.Count > 0) DisplayAll(gameObjects);
    }
        
    private void DisplayAll(List<Object> objects)
    {
      GUILayout.Space(15);
      var title = $"List Count : {objects.Count}";
      GUILayout.BeginVertical(title, "window");
      foreach (var obj in objects)
      {
        Common.Editor.EditorUtils.DisplayObject(obj,new []{obj.name,"Select"});
      }
      GUILayout.EndVertical();
    }
  }
}