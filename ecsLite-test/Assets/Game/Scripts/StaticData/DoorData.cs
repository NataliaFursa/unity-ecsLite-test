using System;
using UnityEngine;

namespace Game.Scripts.StaticData
{
    [Serializable]
    public class DoorData
    {
        [SerializeField]
        private string _id;
        [SerializeField] 
        private Transform _door;
        [SerializeField] 
        private Vector3 _doorTarget;
        [SerializeField] 
        private float _doorSpeed;
        
        public string Id => _id;
        public Transform Door => _door;
        public Vector3 DoorTarget => _doorTarget;
        public float DoorSpeed => _doorSpeed;
    }
}