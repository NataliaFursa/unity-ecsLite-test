using UnityEngine;

namespace Game.Scripts.ECS.Components.Door
{
    public struct DoorComponent
    {
        public string Id;
        public Vector3 Position;
        public Vector3 Direction;
        public float Speed;
    }
}