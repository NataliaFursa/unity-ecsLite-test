using Game.Scripts.ECS.Components.Door;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Door
{
    public class DoorInitSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var data = systems.GetShared<SceneObjectsData>();

            foreach (var room in data.Rooms)
            {
                var doorEntity = ecsWorld.NewEntity();

                var doorPool = ecsWorld.GetPool<DoorComponent>();
                doorPool.Add(doorEntity);

                ref var doorComponent = ref doorPool.Get(doorEntity);
                doorComponent.Id = room.Id;
                doorComponent.Door = room.Door;
                doorComponent.Direction = room.MoveDirection;
                doorComponent.Speed = room.OpenSpeed;
            }
        }
    }
}