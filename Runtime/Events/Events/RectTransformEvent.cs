using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/RectTransform Event")]
    [Serializable]
    public class RectTransformEvent : ASOEvent<RectTransform>
    {
    }
}