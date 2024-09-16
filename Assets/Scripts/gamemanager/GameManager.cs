using System.Collections;
using System.Collections.Generic;
using audio;
using gamemanager;
using player.sanity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private SanityManager sanityManager;
    
    public void Awake()
    {
        ((ISingleton<AudioManager>)audioManager).Setup();
        ((ISingleton<SanityManager>)sanityManager).Setup();
    }
}
