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
            var positionFilter = systems.GetWorld().Filter<PlayerPositionComponent>().End();
            var positionPool = systems.GetWorld().GetPool<PlayerPositionComponent>();

            var buttonFilter = systems.GetWorld().Filter<ButtonComponent>().End();
            var buttonPool = systems.GetWorld().GetPool<ButtonComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);

                foreach (var inputEntity in positionFilter)
                {
                    ref var inputComponent = ref positionPool.Get(inputEntity);

                    buttonComponent.Pressed = 
                        Vector3.Distance(inputComponent.Position, buttonComponent.Position) < buttonComponent.Radius;
                }
            }
        }
    }
}