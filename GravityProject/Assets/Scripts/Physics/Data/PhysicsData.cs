using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Data
{
    [CreateAssetMenuAttribute(fileName = "PhysicsData_")]
    public class PhysicsData : ScriptableObject
    {
        public float forceMultiPlyer;
        public float attractRadius;
    }
}