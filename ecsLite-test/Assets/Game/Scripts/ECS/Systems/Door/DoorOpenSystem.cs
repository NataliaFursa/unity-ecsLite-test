using Game.Scripts.ECS.Components.Door;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Door
{
    public class DoorOpenSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var doorFilter = systems.GetWorld().Filter<DoorComponent>().Inc<DoorTransformComponent>().End();
            var doorPool = systems.GetWorld().GetPool<DoorComponent>();

            var transformPool = systems.GetWorld().GetPool<DoorTransformComponent>();
            
            foreach (var doorEntity in doorFilter)
            {
                ref var doorComponent = ref doorPool.Get(doorEntity);
                ref var transformComponent = ref transformPool.Get(doorEntity);

                transformComponent.Door.position = doorComponent.Position;
            }
        }
    }
}