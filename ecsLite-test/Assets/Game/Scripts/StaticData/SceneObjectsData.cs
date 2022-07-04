using UnityEngine;

namespace Game.Scripts.StaticData
{
    public class SceneObjectsData
    {
        public RoomData[] Rooms { get; }
        public Transform Player { get; }
        public float PlayerSpeed { get; }

        public SceneObjectsData(RoomData[] rooms, Transform player, float playerSpeed)
        {
            Rooms = rooms;
            Player = player;
            PlayerSpeed = playerSpeed;
        }
    }
}