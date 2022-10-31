using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Rect Event")]
    [Serializable]
    public class RectEvent : ASOEvent<Rect>
    {
    }
}