using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Float Event")]
    [Serializable]
    public class FloatEvent : ASOEvent<float>
    {
    }
}