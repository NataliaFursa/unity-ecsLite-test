using Game.Scripts.ECS.Components.Button;
using Game.Scripts.ECS.Components.Door;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Door
{
    public class DoorCalculatingSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var buttonFilter = ecsWorld.Filter<ButtonComponent>().End();
            var buttonPool = ecsWorld.GetPool<ButtonComponent>();

            var doorFilter = ecsWorld.Filter<DoorComponent>().End();
            var doorPool = ecsWorld.GetPool<DoorComponent>();
            
            foreach (var doorEntity in doorFilter)
            {
                ref var doorComponent = ref doorPool.Get(doorEntity);

                foreach (var buttonEntity in buttonFilter)
                {
                    ref var buttonComponent = ref buttonPool.Get(buttonEntity);

                    if (buttonComponent.Pressed && buttonComponent.Id == doorComponent.Id)
                    {
                        doorComponent.Position = Vector3.MoveTowards(doorComponent.Position, 
                            doorComponent.Direction, doorComponent.Speed);
                    }
                }
            }
        }
    }
}