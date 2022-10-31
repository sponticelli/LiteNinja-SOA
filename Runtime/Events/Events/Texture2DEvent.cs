using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Texture2D Event")]
    [Serializable]
    public class Texture2DEvent : ASOEvent<Texture2D>
    {
    }
}