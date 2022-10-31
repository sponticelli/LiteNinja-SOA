using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Quaternion Var", fileName = "QuaternionVar")]
    [Serializable]
    public class QuaternionVar : ASOVar<Quaternion>
    {
    }
}