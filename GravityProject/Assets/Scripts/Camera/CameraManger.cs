using System.Collections;
using System.Collections.Generic;
using Camera.Data;
using UnityEngine;

namespace Camera
{
    public class CameraManger : MonoBehaviour, IInitializable
    {
        private static readonly string CameraMangerName = typeof(CameraManger).Name;
        private static CameraManger _instance;

        private Transform _cameraTarget;
        private Transform _pivot;
        private Transform _cameraTransform;
        
        [SerializeField] private CameraData _cameraDataConfig;

        public static CameraData CameraDataConfig
        {
            get
            {
                if (_instance._cameraDataConfig == null)
                {
                    LogMessage("PlayDataConfig Not Set Up");
                    return null;
                }
                else
                {
                    return _instance._cameraDataConfig;
                }
            }
        }

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
            Debug.Log("<color=blue>" + CameraMangerName + "</color> : " + message);
        }
    }
}
