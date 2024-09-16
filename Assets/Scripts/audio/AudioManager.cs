using System.Collections.Generic;
using System.Linq;
using audio.enums;
using audio.utils;
using gamemanager;
using UnityEngine;

namespace audio
{
    public class AudioManager : BaseSingleton<AudioManager>
    {
        [SerializeField] private List<SFXData> sounds = new();
        [SerializeField] private List<MusicData> themes = new();
    
        private AudioSource mainAudio = null;
    
        public void PlaySound(ESFXType soundType)
        {
            var clip = sounds.FirstOrDefault(s => s.SoundType == soundType)?.AudioClip;
            if (clip == null) return;
    
            var audioSource = new GameObject($"Audio: {soundType}", typeof(AudioSource));
            var audioSourceScript = audioSource.GetComponent<AudioSource>();
            audioSourceScript.volume = PlayerPrefs.GetFloat(Constants.PlayerPrefSFXVolume, 0.1f);
            audioSourceScript.loop = false;
            audioSourceScript.pitch -= Random.Range(-0.1f, 0.1f);
            audioSourceScript.PlayOneShot(clip);
                
            Destroy(audioSource, 0.5f);
        }
    
        public void SetTheme(EMusicType themeType)
        {
            var audioSource = mainAudio;
            if (audioSource == null)
            {
                var audioSourceObj = new GameObject($"Audio: {themeType}", typeof(AudioSource));
                audioSource = audioSourceObj.GetComponent<AudioSource>();
                mainAudio = audioSource;
            }
                
            var clip = themes.FirstOrDefault(s => s.musicType == themeType)?.AudioClip;
            if (clip == null) return;
    
            audioSource.clip = clip;
            audioSource.volume = PlayerPrefs.GetFloat(Constants.PlayerPrefVolume, 0.3f);
            audioSource.loop = true;
            audioSource.Play();
        }
    }   
}