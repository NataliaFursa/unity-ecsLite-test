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
            var buttonFilter = systems.GetWorld().Filter<ButtonComponent>().End();
            var buttonPool = systems.GetWorld().GetPool<ButtonComponent>();

            var doorFilter = systems.GetWorld().Filter<DoorComponent>().End();
            var doorPool = systems.GetWorld().GetPool<DoorComponent>();
            
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