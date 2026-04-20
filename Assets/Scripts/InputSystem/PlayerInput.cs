using EdwinGameDev.Characters;
using UnityEngine;

namespace EdwinGameDev.InputSystem
{
    public class PlayerInput : MonoBehaviour
    {
        private CharacterControllerFacade _character;

        private void Update()
        {
            Vector3 input = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0,
                Input.GetAxisRaw("Vertical")
            );

            _character?.SetDirection(input);
        }

        public void Initialize(CharacterControllerFacade character)
        {
            _character = character;
        }
    }
}