using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
    [CreateAssetMenu(menuName = "LiteNinja/Variables/Rect Var", fileName = "RectVar")]
    [Serializable]
    public class RectVar : ASOVar<Rect>
    {
    }
}