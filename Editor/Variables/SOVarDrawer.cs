using System.Collections.Generic;
using LiteNinja.SOA.Variables;
using UnityEditor;
using UnityEngine;

namespace LiteNinja.SOA.Editor
{

    [CustomEditor(typeof(ASOVar<>), true)]
    public class SOVarDrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (!EditorApplication.isPlaying)
                return;

            var container = (IDrawObjectsInInspector) target;
            var objects = container.GetAllObjects();

            Common.Editor.EditorUtils.DrawLine();

            if (objects.Count > 0)
                DisplayAll(objects);
        }

        private void DisplayAll(List<Object> objects)
        {
            GUILayout.Space(15);
            var title = $"Objects reacting to OnValueChanged Event : {objects.Count}";
            GUILayout.BeginVertical(title, "window");
            foreach (var obj in objects)
            {
                var text = $"{obj.name}  ({obj.GetType().Name})";
                Common.Editor.EditorUtils.DisplayObject(obj, new []{text,"Select"});
            }
            GUILayout.EndVertical();
        }
    }
}