using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Quaternion Event")]
    [Serializable]
    public class QuaternionEvent : ASOEvent<Quaternion>
    {
    }
}