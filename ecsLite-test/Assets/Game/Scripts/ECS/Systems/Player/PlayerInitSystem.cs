using Game.Scripts.ECS.Components.Inputs;
using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly Transform _player;
        private readonly float _speed;
        
        public PlayerInitSystem(Transform player, float speed)
        {
            _player = player;
            _speed = speed;
        }

        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);

            var inputPool = ecsWorld.GetPool<MouseInputComponent>();
            inputPool.Add(playerEntity);
            
            var playerPositionPool = ecsWorld.GetPool<PlayerPositionComponent>();
            playerPositionPool.Add(playerEntity);

            ref var playerComponent = ref playerPool.Get(playerEntity);
            playerComponent.Player = _player;
            playerComponent.Speed = _speed;
            
            ref var inputComponent = ref inputPool.Get(playerEntity);
            inputComponent.InputResult = _player.position;

            ref var playerPositionComponent = ref playerPositionPool.Get(playerEntity);
            playerPositionComponent.Position = _player.position;
        }
    }
}