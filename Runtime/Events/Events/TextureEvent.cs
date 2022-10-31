using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Texture Event")]
    [Serializable]
    public class TextureEvent : ASOEvent<Texture>
    {
    }
}