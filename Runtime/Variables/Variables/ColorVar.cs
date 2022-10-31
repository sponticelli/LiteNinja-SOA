using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Color Var", fileName = "ColorVar")]
    [Serializable]
    public class ColorVar : ASOVar<Color>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(name + "_r", Value.r);
            PlayerPrefs.SetFloat(name + "_g", Value.g);
            PlayerPrefs.SetFloat(name + "_b", Value.b);
            PlayerPrefs.SetFloat(name + "_a", Value.a);
            base.Save();
        }

        public override void Load()
        {
            var r = PlayerPrefs.GetFloat(name + "_r", initialValue.r);
            var g = PlayerPrefs.GetFloat(name + "_g", initialValue.g);
            var b = PlayerPrefs.GetFloat(name + "_b", initialValue.b);
            var a = PlayerPrefs.GetFloat(name + "_a", initialValue.a);
            Value = new Color(r, g, b, a);
            base.Load();
        }

        public void SetRandom()
        {
            var color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Value = color;
        }
    }
}