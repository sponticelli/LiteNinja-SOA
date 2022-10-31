using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Int Var", fileName = "IntVar")]
    [Serializable]
    public class IntVar : ASOVar<int>
    {
        public override void Save()
        {
            base.Save();
            PlayerPrefs.SetInt(this.name, Value);
        }

        public override void Load()
        {
            Value = PlayerPrefs.GetInt(this.name,initialValue);
            base.Load();
        }

        public void Add(int value)
        {
            Value += value;
        }
    }
}