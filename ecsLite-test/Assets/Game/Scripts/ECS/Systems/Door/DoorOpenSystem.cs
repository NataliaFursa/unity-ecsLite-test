using Game.Scripts.ECS.Components.Door;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Door
{
    public class DoorOpenSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var doorFilter = ecsWorld.Filter<DoorComponent>().Inc<DoorTransformComponent>().End();
            var doorPool = ecsWorld.GetPool<DoorComponent>();

            var transformPool = ecsWorld.GetPool<DoorTransformComponent>();
            
            foreach (var doorEntity in doorFilter)
            {
                ref var doorComponent = ref doorPool.Get(doorEntity);
                ref var transformComponent = ref transformPool.Get(doorEntity);

                transformComponent.Door.position = doorComponent.Position;
            }
        }
    }
}