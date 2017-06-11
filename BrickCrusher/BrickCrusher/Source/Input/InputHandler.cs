using BrickCrusher.Source.Core;
using Microsoft.Xna.Framework.Input;

namespace BrickCrusher.Source.Input
{
    public class InputHandler : IDynamic
    {
        //members
        private KeyboardInputData _inputData;

        //constructors
        public InputHandler()
        {
            _inputData = new KeyboardInputData();
        }

        //public methods
        public bool isKeyPressed(Keys key)
        {
            return _inputData.KeysPressed[(int)key];
        }

        public bool isKeyPressedThisFrame(Keys key)
        {
            return _inputData.KeysPressed[(int)key] && !_inputData.KeysPressedLast[(int)key];
        }

        public bool isKeyReleasedThisFrame(Keys key)
        {
            return !_inputData.KeysPressed[(int)key] && _inputData.KeysPressedLast[(int)key];
        }

        public bool isMouseButtonPressed(MouseButton mouseButton)
        {
            return _inputData.ButtonsPressed[(int)mouseButton];
        }

        public bool isMouseButtonPressedThisFrame(MouseButton mouseButton)
        {
            return _inputData.ButtonsPressed[(int)mouseButton] && !_inputData.ButtonsPressedLast[(int)mouseButton];
        }

        public bool isMouseButtonReleasedThisFrame(MouseButton mouseButton)
        {
            return !_inputData.ButtonsPressed[(int)mouseButton] && _inputData.ButtonsPressedLast[(int)mouseButton];
        }

        public bool isMouseScrollUp()
        {
            return _inputData.MouseScroll > _inputData.MouseScrollLast;
        }

        public bool isMouseScrollDown()
        {
            return _inputData.MouseScroll < _inputData.MouseScrollLast;
        }

        public void update(float dt)
        {
            _inputData.update(dt);
        }
    }
}
