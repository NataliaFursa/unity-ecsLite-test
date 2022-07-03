using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerData), menuName = "Data/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private Transform _spawnPoint;

        public Transform SpawnPoint => _spawnPoint;
    }
}