using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/String Event")]
    [Serializable]
    public class StringEvent : ASOEvent<string>
    {
    }
}