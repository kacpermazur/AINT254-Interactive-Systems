using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class CameraManger : MonoBehaviour, IInitializable
    {
        private static readonly string CameramMangerName = typeof(CameraManger).Name;
        private static CameraManger _instance;

        private Transform _cameraTarget;
        private Transform _pivot;
        private Transform _cameraTransform;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            
            Initialize();
        }

        public void Initialize()
        {
            
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=blue>" + CameramMangerName + "</color> : " + message);
        }
    }
}
