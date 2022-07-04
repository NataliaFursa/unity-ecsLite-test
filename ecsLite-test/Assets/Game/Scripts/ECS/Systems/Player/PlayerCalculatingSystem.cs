using Game.Scripts.ECS.Components.Inputs;
using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerCalculatingSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var filter = ecsWorld.Filter<PlayerComponent>().Inc<MouseInputComponent>().End();
            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            var inputPool = ecsWorld.GetPool<MouseInputComponent>();
            
            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                ref var inputComponent = ref inputPool.Get(entity);
                
                playerComponent.Position = Vector3.MoveTowards(playerComponent.Position, 
                    inputComponent.InputResult, playerComponent.Speed);
            }
        }
    }
}