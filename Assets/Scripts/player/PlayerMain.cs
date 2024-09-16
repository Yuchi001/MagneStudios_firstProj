using System;
using System.Linq;
using player.base_class;
using UnityEngine;
using UnityEngine.AI;

namespace player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMain : MonoBehaviour
    {
        private NavMeshAgent agent;
        public NavMeshAgent PlayerAgent => agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            GetComponents<PlayerComponentBase>().ToList().ForEach(p => p.PlayerSetup());
        }
    }
}
