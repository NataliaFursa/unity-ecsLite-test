using Game.Scripts.ECS.Components.Inputs;
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
            var data = systems.GetShared<SceneObjectsData>();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);

            var inputPool = ecsWorld.GetPool<MouseInputComponent>();
            inputPool.Add(playerEntity);

            ref var playerComponent = ref playerPool.Get(playerEntity);
            playerComponent.Player = data.Player;
            playerComponent.Speed = data.PlayerSpeed;
            
            ref var inputComponent = ref inputPool.Get(playerEntity);
            inputComponent.InputResult = data.Player.position;
        }
    }
}