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
 
        [SerializeField] private Transform _offSet;
        [SerializeField] private Transform _pivot;
        [SerializeField] private Transform _pivotZ;
        [SerializeField] private Transform _cameraTransform;
     
        [SerializeField] private CameraData _cameraDataConfig;

        private CameraController _cameraController;

        public static CameraData CameraDataConfig
        {
            get
            {
                if (_instance._cameraDataConfig == null)
                {
                    LogMessage("DataConfig Not Set Up");
                    return null;
                }
                else
                {
                    return _instance._cameraDataConfig;
                }
            }
        }
        
        public static Transform OffSet{ get { return _instance._offSet; }}
        public static Transform CameraPivot{ get { return _instance._pivot; }}
        public static Transform CameraPivotZ{ get { return _instance._pivotZ; }}
        public static Transform CameraTransform{ get { return _instance._cameraTransform; }}
        
        public static CameraController CameraController{ get { return _instance._cameraController; }}

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
            
            CameraController.Initialize();
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=blue>" + CameraMangerName + "</color> : " + message);
        }
    }
}
