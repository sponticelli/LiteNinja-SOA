using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Transform Event")]
    [Serializable]
    public class TransformEvent : ASOEvent<Transform>
    {
    }
}