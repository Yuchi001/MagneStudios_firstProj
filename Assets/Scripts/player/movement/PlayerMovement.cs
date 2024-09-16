using System;
using System.Collections.Generic;
using player.base_class;
using UnityEngine;

namespace player.movement
{
    public class PlayerMovement : PlayerComponentBase
    {
        private void Update()
        {
            if(Input.GetMouseButtonDown(0)) ManageClick();
        }

        private void ManageClick()
        {
            var rawMousePosition = Input.mousePosition;
            var mainCamera = Camera.main;
            if (!mainCamera) return;
            var destination = mainCamera.ScreenToWorldPoint(rawMousePosition);
            PlayerMain.PlayerAgent.SetDestination(destination);
        }
    }
}
