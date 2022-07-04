using Game.Scripts.Behaviours;
using Game.Scripts.ECS.Systems.Button;
using Game.Scripts.ECS.Systems.Door;
using Game.Scripts.ECS.Systems.Player;
using Leopotam.EcsLite;

namespace Game.Scripts.Providers.Systems
{
    public class InitSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _initSystems;

        public InitSystemsProvider(EcsWorld ecsWorld, World world)
        {
            _initSystems = new EcsSystems(ecsWorld);
            _initSystems.Add(new PlayerInitSystem(world.Player, world.PlayerSpeed));
            _initSystems.Add(new ButtonInitSystem(world.Buttons));
            _initSystems.Add(new DoorInitSystem(world.Doors));
            
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