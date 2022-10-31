using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/GameObject Var", fileName = "GameObjectVar")]
    [Serializable]
    public class GameObjectVar : ASOVar<AudioClip>
    {
    }
}