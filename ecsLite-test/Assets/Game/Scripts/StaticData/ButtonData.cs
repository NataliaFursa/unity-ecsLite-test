using System;
using UnityEngine;

namespace Game.Scripts.StaticData
{
    [Serializable]
    public class ButtonData
    {
        [SerializeField] 
        private string _id;
        [SerializeField]
        private Vector3 _buttonPosition;
        [SerializeField] 
        private int _buttonRadius;

        public string Id => _id;
        public Vector3 ButtonPosition => _buttonPosition;
        public int ButtonRadius => _buttonRadius;
    }
}