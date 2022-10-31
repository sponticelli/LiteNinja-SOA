using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Vector4 Var", fileName = "Vector4Var")]
    [Serializable]
    public class Vector4Var : ASOVar<Vector4>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.name + "_x", Value.x);
            PlayerPrefs.SetFloat(this.name + "_y", Value.y);
            PlayerPrefs.SetFloat(this.name + "_z", Value.z);
            PlayerPrefs.SetFloat(this.name + "_w", Value.w);
            base.Save();
        }

        public override void Load()
        {
            var x = PlayerPrefs.GetFloat(this.name + "_x", initialValue.x);
            var y = PlayerPrefs.GetFloat(this.name + "_y", initialValue.y);
            var z = PlayerPrefs.GetFloat(this.name + "_z", initialValue.z);
            var w = PlayerPrefs.GetFloat(this.name + "_w", initialValue.w);
            Value = new Vector4(x,y,z,w);
            base.Load();
        }
    }
}