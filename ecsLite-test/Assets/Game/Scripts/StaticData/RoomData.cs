using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(RoomData), menuName = "Data/RoomData", order = 0)]
    public class RoomData : ScriptableObject
    {
        [SerializeField] 
        private Transform _door;
        [SerializeField] 
        private Transform _button;

        public Transform Door => _door;
        public Transform Button => _button;
    }
}