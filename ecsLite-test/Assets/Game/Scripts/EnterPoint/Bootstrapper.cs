using Game.Scripts.Behaviours;
using Game.Scripts.Providers.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.EnterPoint
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private World _world;

        private EcsWorld _ecsWorld;
        private ISystemProvider _initSystemProvider;
        private ISystemProvider _updateSystemProvider;
        private ISystemProvider _fixedUpdateSystemProvider;
        
        private void Start()
        {
            _ecsWorld = new EcsWorld();
            
            _initSystemProvider = new InitSystemsProvider(_ecsWorld, _world);
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