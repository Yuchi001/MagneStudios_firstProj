using Unity.VisualScripting;
using UnityEngine;

namespace gamemanager
{
    public abstract class BaseSingleton<T> : MonoBehaviour, ISingleton<T> where T : MonoBehaviour
    {
        private bool setup = false;
        
        public void Setup(params object[] objectParams)
        {
            if (ISingleton<T>.Instance != null && ISingleton<T>.Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            ISingleton<T>.Instance = this as T;
            
            if (setup) return;
            OnSetup(objectParams);
            setup = true;
        }

        public virtual void OnSetup(params object[] objectParams)
        {
            
        }
    }
}