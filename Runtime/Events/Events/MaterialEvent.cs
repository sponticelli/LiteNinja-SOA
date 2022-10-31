using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Material Event")]
    [Serializable]
    public class MaterialEvent : ASOEvent<int>
    {
    }
}