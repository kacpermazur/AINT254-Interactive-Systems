using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Input
{
    public struct InputHandler
    {
        public static float Vertical()
        {
            return UnityEngine.Input.GetAxis("Vertical");
        }
        
        public static float Horizontal()
        {
            return UnityEngine.Input.GetAxis("Horizontal");
        }

        public static bool Jump()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }
    }
}