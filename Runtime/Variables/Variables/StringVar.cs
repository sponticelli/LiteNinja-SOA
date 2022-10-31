using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/String Var", fileName = "StringVar")]
    [Serializable]
    public class StringVar : ASOVar<string>
    {
        public override void Save()
        {
            PlayerPrefs.SetString(this.name, Value);
            base.Save();
        }

        public override void Load()
        {
            Value = PlayerPrefs.GetString(this.name);
            base.Load();
        }
    }
}