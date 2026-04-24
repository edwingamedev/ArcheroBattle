using Cinemachine;
using EdwinGameDev.Character;
using EdwinGameDev.Spawn;
using UnityEngine;

namespace EdwinGameDev.CameraUtils
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera vcam;
        [SerializeField] UnitSpawner unitSpawner;

        private void Awake()
        {
            unitSpawner.OnHeroSpawn += UnitSpawnerOnOnHeroSpawn;
        }

        private void OnDestroy()
        {
            unitSpawner.OnHeroSpawn -= UnitSpawnerOnOnHeroSpawn;
        }

        private void UnitSpawnerOnOnHeroSpawn(CharacterAdapter obj)
        {
            vcam.Follow = obj.transform;
        }
    }
}