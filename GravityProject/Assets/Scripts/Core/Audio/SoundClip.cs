using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Core.Audio
{
    [System.Serializable]
    public class SoundClip
    {
        public string Name;
        public AudioClip Audio;

        public bool Loop;
        
        [Range(0.0f, 1.0f)] public float Volume;
        [Range(0.0f, 1.0f)] public float Pitch;
        [Range(0.0f, 1.0f)] public float SpacialBlend;

        [HideInInspector] public AudioSource Source;
    }
}