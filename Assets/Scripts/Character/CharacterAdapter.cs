using UnityEngine;

namespace EdwinGameDev.Character
{
    public class CharacterAdapter : MonoBehaviour
    {
        private CharacterControllerFacade _character;

        public void Initialize(CharacterControllerFacade character)
        {
            _character = character;
        }

        private void Update()
        {
            _character?.Tick(Time.deltaTime);
        }
    }
}