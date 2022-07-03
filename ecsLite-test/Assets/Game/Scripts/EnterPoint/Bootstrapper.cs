using Game.Scripts.Behaviours;
using Game.Scripts.ECS.Systems;
using Game.Scripts.Providers.Systems;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.EnterPoint
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private World _world;
        [SerializeField] 
        private Transform _player;
        [SerializeField] 
        private float _playerSpeed;

        private EcsWorld _ecsWorld;
        private ISystemProvider _initSystemProvider;
        private ISystemProvider _updateSystemProvider;
        private ISystemProvider _fixedUpdateSystemProvider;
        
        private void Start()
        {
            var sceneSharedData = new SceneSharedData(_world.Rooms, _player, _playerSpeed);

            _ecsWorld = new EcsWorld();
            
            _initSystemProvider = new InitSystemsProvider(_ecsWorld, sceneSharedData);
            _updateSystemProvider = new UpdateSystemsProvider(_ecsWorld);
            _fixedUpdateSystemProvider = new FixedUpdateSystemsProvider(_ecsWorld);
        }

        private void Update()
        {
            _updateSystemProvider.Operate();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystemProvider.Operate();
        }

        private void OnDestroy()
        {
            _initSystemProvider.Dispose();
            _updateSystemProvider.Dispose();
            _fixedUpdateSystemProvider.Dispose();
            
            _ecsWorld.Destroy();
        }
    }
}