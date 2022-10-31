using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Sprite Event")]
    [Serializable]
    public class SpriteEvent : ASOEvent<Sprite>
    {
    }
}