using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Vector3 Var", fileName = "Vector3Var")]
    [Serializable]
    public class Vector3Var : ASOVar<Vector3>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.name + "_x", Value.x);
            PlayerPrefs.SetFloat(this.name + "_y", Value.y);
            PlayerPrefs.SetFloat(this.name + "_z", Value.z);
            base.Save();
        }

        public override void Load()
        {
            var x = PlayerPrefs.GetFloat(this.name + "_x", initialValue.x);
            var y = PlayerPrefs.GetFloat(this.name + "_y", initialValue.y);
            var z = PlayerPrefs.GetFloat(this.name + "_z", initialValue.z);
            Value = new Vector3(x,y,z);
            base.Load();
        }
    }
}