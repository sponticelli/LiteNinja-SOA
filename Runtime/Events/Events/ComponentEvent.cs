using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Component Event")]
    [Serializable]
    public class ComponentEvent : ASOEvent<Component>
    {
    }
}