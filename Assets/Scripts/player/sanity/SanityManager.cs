using System;
using gamemanager;
using UnityEngine;

namespace player.sanity
{
    public class SanityManager : BaseSingleton<SanityManager>
    {
        [SerializeField, Min(1)] private int maxSanity;

        public override void OnSetup(params object[] objectParams)
        {
            Debug.Log("VAR");
        }

        private int _currentSanity = 0;

        public int GetCurrentSanity()
        {
            return _currentSanity;
        }

        public float GetSanityPercentage()
        {
            return (float)_currentSanity / maxSanity;
        }
    }
}