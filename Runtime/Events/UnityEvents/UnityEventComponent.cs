using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [Serializable]
    public class UnityEventComponent : UnityEvent<Component>
    {
    }
}