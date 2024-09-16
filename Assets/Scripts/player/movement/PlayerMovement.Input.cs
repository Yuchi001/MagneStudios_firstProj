﻿using System.Collections.Generic;
using UnityEngine;

namespace player.movement
{
    public partial class PlayerMovement
    {
        private Dictionary<KeyCode, bool> _buttonsActive;
        private static KeyCode UpBind => KeyCode.W;
        private static KeyCode DownBind => KeyCode.S;
        private static KeyCode LeftBind => KeyCode.A;
        private static KeyCode RightBind => KeyCode.D;
        
        private Vector2 GetVelocity()
        {
            var movement = Vector2.zero;

            CheckKey(UpBind, DownBind);
            CheckKey(LeftBind, RightBind);

            movement.x = _buttonsActive[RightBind] ? 1 : (_buttonsActive[LeftBind] ? -1 : 0);
            movement.y = _buttonsActive[UpBind] ? 1 : (_buttonsActive[DownBind] ? -1 : 0);

            if(movement == Vector2.zero) return Vector2.zero;
            
            // TODO: make it a constant
            return movement * 2;
        }

        private void CheckKey(KeyCode main, KeyCode opposite)
        {
            if (Input.GetKeyDown(main))
            {
                _buttonsActive[main] = true;
                _buttonsActive[opposite] = false;
            }
            if (Input.GetKeyDown(opposite))
            {
                _buttonsActive[opposite] = true;
                _buttonsActive[main] = false;
            }

            if (Input.GetKeyUp(main))
            {
                if (Input.GetKey(opposite))
                {
                    _buttonsActive[opposite] = true;
                }
                _buttonsActive[main] = false;
            }

            if (Input.GetKeyUp(opposite))
            {
                if (Input.GetKey(main))
                {
                    _buttonsActive[main] = true;
                }
                _buttonsActive[opposite] = false;
            }
        }
    }
}