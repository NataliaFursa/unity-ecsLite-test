using Game.Scripts.ECS.Components.Button;
using Game.Scripts.ECS.Components.Inputs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.ECS.Systems.Button
{
    public class ButtonPressSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var inputFilter = systems.GetWorld().Filter<MouseInputComponent>().End();
            var inputPool = systems.GetWorld().GetPool<MouseInputComponent>();

            var buttonFilter = systems.GetWorld().Filter<ButtonComponent>().End();
            var buttonPool = systems.GetWorld().GetPool<ButtonComponent>();

            foreach (var buttonEntity in buttonFilter)
            {
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);

                foreach (var inputEntity in inputFilter)
                {
                    ref var inputComponent = ref inputPool.Get(inputEntity);

                    buttonComponent.Pressed = 
                        Vector3.Distance(inputComponent.InputResult, buttonComponent.Position) < buttonComponent.Radius;
                }
            }
        }
    }
}