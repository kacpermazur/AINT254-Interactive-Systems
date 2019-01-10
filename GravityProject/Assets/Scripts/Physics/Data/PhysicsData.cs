using UnityEngine;

namespace Physics.Data
{
    [CreateAssetMenuAttribute(fileName = "PhysicsData_")]
    public class PhysicsData : ScriptableObject
    {
        public float forceMultiplier;
        public float attractRadius;
    }
}