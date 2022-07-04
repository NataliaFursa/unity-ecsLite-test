using Game.Scripts.StaticData;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class World : MonoBehaviour
    {
        [SerializeField]
        private ButtonData[] _buttons;
        [SerializeField] 
        private DoorData[] _doors;
        [SerializeField] 
        private Transform _player;
        [SerializeField] 
        private float _playerSpeed;
        
        public ButtonData[] Buttons => _buttons;
        public DoorData[] Doors => _doors;
        public Transform Player => _player;
        public float PlayerSpeed => _playerSpeed;
    }
}