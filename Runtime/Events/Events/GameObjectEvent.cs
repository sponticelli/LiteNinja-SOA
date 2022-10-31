using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/GameObject Event")]
    [Serializable]
    public class GameObjectEvent : ASOEvent<GameObject>
    {
    }
}