using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Int Event")]
    [Serializable]
    public class IntEvent : ASOEvent<int>
    {
    }
}