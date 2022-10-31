using System;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/AudioClip Event")]
    [Serializable]
    public class AudioClipEvent : ASOEvent<AudioClip>
    {
    }
}