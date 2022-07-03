using Game.Scripts.ECS.Systems.Player;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class UpdateSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _updateSystems;
        
        public UpdateSystemsProvider(EcsWorld ecsWorld)
        {
            _updateSystems = new EcsSystems(ecsWorld);
            _updateSystems.Add(new PlayerInputSystem());
            
            _updateSystems.Init();
        }

        public void Dispose()
        {
            _updateSystems.Destroy();
        }

        public void Operate()
        {
            _updateSystems.Run();
        }
    }
}