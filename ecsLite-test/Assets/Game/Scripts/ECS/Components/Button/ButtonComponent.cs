using UnityEngine;

namespace Game.Scripts.ECS.Components.Button
{
    public struct ButtonComponent
    {
        public string Id;
        public bool Pressed;
        public Vector3 Position;
        public float Radius;
    }
}