using System;
using UnityEngine;

namespace Game.Scripts.StaticData
{
    [Serializable]
    public class RoomData
    {
        [SerializeField] 
        private string _id;
        [SerializeField]
        private Transform _door;
        [SerializeField] 
        private Vector3 _moveDirection;
        [SerializeField] 
        private float _openSpeed;
        [SerializeField]
        private Transform _button;

        public string Id => _id;
        public Transform Door => _door;
        public Vector3 MoveDirection => _moveDirection;
        public float OpenSpeed => _openSpeed;
        public Transform Button => _button;
    }
}