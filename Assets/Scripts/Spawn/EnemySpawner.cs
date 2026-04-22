using EdwinGameDev.Spawn.Factories;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        private void Start()
        {
            EnemyFactory factory = new EnemyFactory();

            for (int i = 0; i < 3; i++)
            {
                factory.Create(enemyPrefab, new Vector3(i * 2f, 0, 5f));
            }
        }
    }
}