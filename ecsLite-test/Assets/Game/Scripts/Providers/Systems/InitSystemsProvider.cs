using Game.Scripts.ECS.Systems.Button;
using Game.Scripts.ECS.Systems.Player;
using Game.Scripts.StaticData;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class InitSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _initSystems;

        public InitSystemsProvider(EcsWorld ecsWorld, SceneObjectsData sceneObjectsData)
        {
            _initSystems = new EcsSystems(ecsWorld, sceneObjectsData);
            _initSystems.Add(new PlayerInitSystem());
            _initSystems.Add(new ButtonInitSystem());
            
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