using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Vector2 Var", fileName = "Vector2Var")]
    [Serializable]
    public class Vector2Var : ASOVar<Vector2>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.name + "_x", Value.x);
            PlayerPrefs.SetFloat(this.name + "_y", Value.y);
            base.Save();
        }

        public override void Load()
        {
            var x = PlayerPrefs.GetFloat(this.name + "_x", initialValue.x);
            var y = PlayerPrefs.GetFloat(this.name + "_y", initialValue.y);
            Value = new Vector2(x,y);
            base.Load();
        }
    }
}