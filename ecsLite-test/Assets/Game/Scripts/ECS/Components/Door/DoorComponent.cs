using UnityEngine;

namespace Game.Scripts.ECS.Components.Door
{
    public struct DoorComponent
    {
        public string Id;
        public Transform Door;
        public Vector3 Direction;
        public float Speed;
    }
}