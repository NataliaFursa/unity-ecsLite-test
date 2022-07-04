using Game.Scripts.ECS.Components.Button;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Button
{
    public class ButtonInitSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var data = systems.GetShared<SceneObjectsData>();

            foreach (var room in data.Rooms)
            {
                var buttonEntity = ecsWorld.NewEntity();

                var buttonPool = ecsWorld.GetPool<ButtonComponent>();
                buttonPool.Add(buttonEntity);

                ref var buttonComponent = ref buttonPool.Get(buttonEntity);
                buttonComponent.Id = room.Id;
                buttonComponent.Position = room.Button.position;
                buttonComponent.Pressed = false;
                buttonComponent.Radius = 2;
            }
        }
    }
}