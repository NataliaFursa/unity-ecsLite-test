using Game.Scripts.ECS.Systems.Player;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class InitSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _initSystems;

        public InitSystemsProvider(EcsWorld ecsWorld, SceneSharedData sceneSharedData)
        {
            _initSystems = new EcsSystems(ecsWorld, sceneSharedData);
            _initSystems.Add(new PlayerInitSystem());
            
            _initSystems.Init();
        }

        public void Dispose()
        {
            _initSystems.Destroy();
        }
        
        public void Operate()
        {
            //no impl
        }
    }
}