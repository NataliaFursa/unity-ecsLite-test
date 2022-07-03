using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerInputComponent>().End();
            var playerInputPool = systems.GetWorld().GetPool<PlayerInputComponent>();

            var mousePositionChanged = TryGetMousePosition(out var mousePosition);
            
            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                if (mousePositionChanged)
                {
                    playerInputComponent.InputResult = mousePosition;
                }
            }
        }

        private bool TryGetMousePosition(out Vector3 mousePosition)
        {
            mousePosition = Vector3.zero;

            if (!Input.GetMouseButtonDown(0))
            {
                return false;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit))
            {
                return false;
            }

            mousePosition = hit.point;
            return true;
        }
    }
}