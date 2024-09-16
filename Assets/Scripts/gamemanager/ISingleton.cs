using UnityEngine;

namespace gamemanager
{
    public interface ISingleton<out T> where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        public void Setup(params object[] objectParams);
    }
}