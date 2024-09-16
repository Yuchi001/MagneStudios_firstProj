using audio.enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace audio.utils
{
    [System.Serializable]
    public class MusicData
    {
        public AudioClip AudioClip;
        public EMusicType musicType;
    }
}