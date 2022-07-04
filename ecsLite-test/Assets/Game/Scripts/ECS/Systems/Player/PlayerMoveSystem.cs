using Game.Scripts.ECS.Components.Inputs;
using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerComponent>().Inc<MouseInputComponent>().End();
            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();
            var inputPool = systems.GetWorld().GetPool<MouseInputComponent>();
            
            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                ref var inputComponent = ref inputPool.Get(entity);

                playerComponent.Player.position = Vector3.MoveTowards(playerComponent.Player.position, 
                    inputComponent.InputResult, playerComponent.Speed);
            }
        }
    }
}