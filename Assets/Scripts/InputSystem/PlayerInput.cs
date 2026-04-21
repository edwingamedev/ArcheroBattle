using EdwinGameDev.Characters;
using EdwinGameDev.Utils.Joystick;
using UnityEngine;

namespace EdwinGameDev.InputSystem
{
    public class PlayerInput : MonoBehaviour
    {
        private Joystick _joystick;
        private CharacterControllerFacade _character;

        private void Awake()
        {
            _joystick = FindObjectOfType<Joystick>();
        }

        private void Update()
        {
            Vector3 input;

            // Use joystick if available and being used, otherwise fall back to keyboard
            if (_joystick && _joystick.Direction.sqrMagnitude > 0.01f)
            {
                input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            }
            else
            {
                input = new Vector3(
                    Input.GetAxisRaw("Horizontal"),
                    0,
                    Input.GetAxisRaw("Vertical")
                );
            }

            _character?.SetDirection(input);
        }

        public void Initialize(CharacterControllerFacade character)
        {
            _character = character;
        }
    }
}