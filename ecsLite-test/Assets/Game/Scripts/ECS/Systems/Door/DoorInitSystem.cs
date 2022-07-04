using Game.Scripts.ECS.Components.Door;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Door
{
    public class DoorInitSystem : IEcsInitSystem
    {
        private readonly DoorData[] _doors;
        
        public DoorInitSystem(DoorData[] doors)
        {
            _doors = doors;
        }

        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();

            foreach (var door in _doors)
            {
                var doorEntity = ecsWorld.NewEntity();

                var transformPool = ecsWorld.GetPool<DoorTransformComponent>();
                transformPool.Add(doorEntity);
                
                var doorPool = ecsWorld.GetPool<DoorComponent>();
                doorPool.Add(doorEntity);

                ref var transformComponent = ref transformPool.Get(doorEntity);
                transformComponent.Door = door.Door;

                ref var doorComponent = ref doorPool.Get(doorEntity);
                doorComponent.Id = door.Id;
                doorComponent.Position = door.Door.position;
                doorComponent.Direction = door.DoorTarget;
                doorComponent.Speed = door.DoorSpeed;
            }
        }
    }
}