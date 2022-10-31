using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Bool Var", fileName = "BoolVar")]
    [Serializable]
    public class BoolVar : ASOVar<bool>
    {
        public override void Save()
        {
            base.Save();
            PlayerPrefs.SetInt(name, Value ? 1 : 0);
        }

        public override void Load()
        {
            Value = PlayerPrefs.GetInt(name) > 0;
            base.Load();
        }

        public void Toggle()
        {
            Value = !Value;
        }
    }
}