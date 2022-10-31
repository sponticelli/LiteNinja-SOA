using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Double Event")]
    [Serializable]
    public class DoubleEvent : ASOEvent<double>
    {
    }
}