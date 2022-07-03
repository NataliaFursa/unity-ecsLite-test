using Game.Scripts.ECS.Components.Player;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var data = systems.GetShared<SceneSharedData>();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);

            var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
            playerInputPool.Add(playerEntity);

            ref var playerComponent = ref playerPool.Get(playerEntity);
            playerComponent.Player = data.Player;
            playerComponent.Speed = data.PlayerSpeed;
            
            ref var playerInputComponent = ref playerInputPool.Get(playerEntity);
            playerInputComponent.InputResult = data.Player.position;
        }
    }
}