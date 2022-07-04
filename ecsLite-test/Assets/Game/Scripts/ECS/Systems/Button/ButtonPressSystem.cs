using Game.Scripts.ECS.Components.Button;
using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Button
{
    public class ButtonPressSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var playerFilter = ecsWorld.Filter<PlayerComponent>().End();
            var playerPool = ecsWorld.GetPool<PlayerComponent>();

            var buttonFilter = ecsWorld.Filter<ButtonComponent>().End();
            var buttonPool = ecsWorld.GetPool<ButtonComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);

                foreach (var inputEntity in playerFilter)
                {
                    ref var inputComponent = ref playerPool.Get(inputEntity);

                    buttonComponent.Pressed = 
                        Vector3.Distance(inputComponent.Position, buttonComponent.Position) < buttonComponent.Radius;
                }
            }
        }
    }
}