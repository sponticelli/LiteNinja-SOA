using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Bool Event")]
    [Serializable]
    public class BoolEvent : ASOEvent<bool>
    {
    }
}