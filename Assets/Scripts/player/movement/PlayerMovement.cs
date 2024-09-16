using System.Collections.Generic;
using UnityEngine;

namespace player.movement
{
    public partial class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float animationSpeed = 0.5f;
        [SerializeField] private Animator animator;

        public bool LookingRight => _lookingRight;
        private bool _lookingRight;
        
        private void Awake()
        {
            animator.speed = animationSpeed;
            _buttonsActive = new Dictionary<KeyCode, bool>
            {
                { UpBind, false },
                { LeftBind, false },
                { DownBind, false },
                { RightBind, false },
            };
        }

        protected void Update()
        {
            // TODO: Player death movement handling
            ManageMovement();
        }

        private void ManageMovement()
        {
            var velocity = GetVelocity();
            rb2d.velocity = velocity;
            animator.SetBool("isWalking", velocity != Vector2.zero);

            if (velocity.x == 0) return;

            _lookingRight = velocity.x > 0;
            transform.rotation = Quaternion.Euler(0, _lookingRight ? 180 : 0, 0);
        }
    }
}
