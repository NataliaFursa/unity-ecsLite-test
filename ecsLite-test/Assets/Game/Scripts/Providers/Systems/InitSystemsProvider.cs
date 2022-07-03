using Game.Scripts.ECS.Systems;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class InitSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _initSystems;

        public InitSystemsProvider(EcsWorld ecsWorld)
        {
            _initSystems = new EcsSystems(ecsWorld);
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