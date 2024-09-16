using UnityEngine;

namespace player.base_class
{
    [RequireComponent(typeof(PlayerMain))]
    public class PlayerComponentBase : MonoBehaviour
    {
        private PlayerMain _playerMain;

        protected PlayerMain PlayerMain
        {
            get
            {
                if (_playerMain) return _playerMain;
                _playerMain = GetComponent<PlayerMain>();
                return _playerMain;
            }
        }

        public virtual void PlayerSetup() { }
    }
}