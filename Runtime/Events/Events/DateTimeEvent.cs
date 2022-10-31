using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/DateTime Event")]
    [Serializable]
    public class DateTimeEvent : ASOEvent<DateTime>
    {
    }
}