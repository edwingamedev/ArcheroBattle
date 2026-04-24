using EdwinGameDev.Character;
using UnityEngine;

namespace EdwinGameDev.Input
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        private Joystick _joystick;
        private CharacterAdapter _character;

        private void Awake()
        {
            _joystick = FindObjectOfType<Joystick>();
        }

        public void Initialize(CharacterAdapter character)
        {
            _character = character;
        }
        
        private void Update()
        {
            Vector3 input;
            
            if (_joystick && _joystick.Direction.sqrMagnitude > 0.01f)
            {
                input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            }
            else
            {
                input = new Vector3(
                    UnityEngine.Input.GetAxisRaw("Horizontal"),
                    0,
                    UnityEngine.Input.GetAxisRaw("Vertical")
                );
            }

            _character?.Move(input);
        }
    }
}