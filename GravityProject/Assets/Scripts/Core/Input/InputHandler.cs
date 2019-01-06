namespace Core.Input
{
    using UnityEngine;
    
    public struct InputHandler
    {
        public static bool Escape()
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
        
        public static bool Shoot()
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }
        
    }
}