using System.Collections;
using System.Collections.Generic;
using Camera.Data;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(CameraController))]
    public class CameraManger : MonoBehaviour, IInitializable
    {
        private static readonly string CameraMangerName = typeof(CameraManger).Name;
        private static CameraManger _instance;

        [SerializeField] private Transform _cameraTarget;   
        [SerializeField] private Transform _pivot;
        [SerializeField] private Transform _cameraTransform;
     
        [SerializeField] private CameraData _cameraDataConfig;

        private CameraController _cameraController;

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
        
        public static Transform GetCameraTarget{ get { return _instance._cameraTarget; }}
        public static Transform CameraPivot{ get { return _instance._pivot; }}
        public static Transform CameraTransform{ get { return _instance._cameraTransform; }}

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
            _cameraController = GetComponent<CameraController>();
            
            LogMessage(_cameraTarget.position.ToString());
            LogMessage(_pivot.position.ToString());
            LogMessage(_cameraTransform.position.ToString());
            
            _cameraController.Initialize();
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=blue>" + CameraMangerName + "</color> : " + message);
        }
    }
}
