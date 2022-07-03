using Game.Scripts.StaticData;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class World : MonoBehaviour
    {
        [SerializeField]
        private RoomData[] _rooms;
        
        public RoomData[] Rooms => _rooms;
    }
}