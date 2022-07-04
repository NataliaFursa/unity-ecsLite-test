using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerTransformComponent>().Inc<PlayerComponent>().End();
            var transformPool = systems.GetWorld().GetPool<PlayerTransformComponent>();

            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();
            
            foreach (var entity in filter)
            {
                ref var transformComponent = ref transformPool.Get(entity);
                ref var playerComponent = ref playerPool.Get(entity);

                transformComponent.Player.position = playerComponent.Position;
            }
        }
    }
}