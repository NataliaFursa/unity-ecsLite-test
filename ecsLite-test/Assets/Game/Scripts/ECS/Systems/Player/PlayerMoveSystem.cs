using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var filter = ecsWorld.Filter<PlayerTransformComponent>().Inc<PlayerComponent>().End();
            var transformPool = ecsWorld.GetPool<PlayerTransformComponent>();
            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            
            foreach (var entity in filter)
            {
                ref var transformComponent = ref transformPool.Get(entity);
                ref var playerComponent = ref playerPool.Get(entity);

                transformComponent.Player.position = playerComponent.Position;
            }
        }
    }
}