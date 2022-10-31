using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Vector3 Event")]
    [Serializable]
    public class Vector3Event : ASOEvent<Vector3>
    {
    }
}