namespace Core.Input
{
    using UnityEngine;
    
    public struct InputHandler
    {
        public static float Vertical()
        {
            return Input.GetAxis("Vertical");
        }
        
        public static float Horizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        public static bool Jump()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public static bool FlipGravity()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public static bool Shoot()
        {
            return Input.GetKeyDown("Fire1");
        }
    }
}