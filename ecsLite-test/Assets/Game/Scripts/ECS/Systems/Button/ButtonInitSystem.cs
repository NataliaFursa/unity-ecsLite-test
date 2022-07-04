using Game.Scripts.ECS.Components.Button;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Button
{
    public class ButtonInitSystem : IEcsInitSystem
    {
        private readonly ButtonData[] _rooms;
        
        public ButtonInitSystem(ButtonData[] rooms)
        {
            _rooms = rooms;
        }

        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();

            foreach (var room in _rooms)
            {
                var buttonEntity = ecsWorld.NewEntity();

                var buttonPool = ecsWorld.GetPool<ButtonComponent>();
                buttonPool.Add(buttonEntity);

                ref var buttonComponent = ref buttonPool.Get(buttonEntity);
                buttonComponent.Id = room.Id;
                buttonComponent.Position = room.ButtonPosition;
                buttonComponent.Pressed = false;
                buttonComponent.Radius = room.ButtonRadius;
            }
        }
    }
}