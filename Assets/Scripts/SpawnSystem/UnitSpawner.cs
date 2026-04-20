using System;
using EdwinGameDev.Characters;
using EdwinGameDev.InputSystem;
using EdwinGameDev.MovementSystem;
using UnityEngine;

namespace EdwinGameDev.SpawnSystem
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject heroPrefab;

        private void Start()
        {
            SpawnHero();
        }

        private void SpawnHero()
        {
            Vector3 initialPosition = new Vector3(0, 0, 0);
            Quaternion initialRotation = Quaternion.identity;

            GameObject heroGO = Instantiate(heroPrefab, initialPosition, initialRotation);
            HeroFactory factory = new HeroFactory();

            CharacterControllerFacade character = factory.Create(heroGO);

            heroGO.GetComponent<PlayerInput>().Initialize(character);
        }
    }
}