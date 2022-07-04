using Game.Scripts.ECS.Systems.Door;
using Game.Scripts.ECS.Systems.Player;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class FixedUpdateSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _fixedUpdateSystems;
        
        public FixedUpdateSystemsProvider(EcsWorld ecsWorld)
        {
            _fixedUpdateSystems = new EcsSystems(ecsWorld);
            _fixedUpdateSystems.Add(new PlayerCalculatingSystem());
            _fixedUpdateSystems.Add(new PlayerMoveSystem());
            _fixedUpdateSystems.Add(new DoorCalculatingSystem());
            _fixedUpdateSystems.Add(new DoorOpenSystem());
            
            _fixedUpdateSystems.Init();
        }

        public void Dispose()
        {
            _fixedUpdateSystems.Destroy();
        }

        public void Operate()
        {
            _fixedUpdateSystems.Run();
        }
    }
}