using System;
using UnityEngine;

namespace Game.Scripts.StaticData
{
    [Serializable]
    public class RoomData
    {
        [SerializeField]
        private Transform _door;
        [SerializeField]
        private Transform _button;

        public Transform Door => _door;
        public Transform Button => _button;
    }
}