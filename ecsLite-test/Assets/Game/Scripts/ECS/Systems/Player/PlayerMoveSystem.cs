using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerComponent>().Inc<PlayerInputComponent>().End();
            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();
            var playerInputPool = systems.GetWorld().GetPool<PlayerInputComponent>();
            
            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                playerComponent.Player.position = Vector3.MoveTowards(playerComponent.Player.position, 
                    playerInputComponent.InputResult, 
                    playerComponent.Speed);
            }
        }
    }
}