using BrickCrusher.Source.Core;
using Microsoft.Xna.Framework.Input;

namespace BrickCrusher.Source.Input
{
    public enum MouseButton { LEFT, MIDDLE, RIGHT }

    public class KeyboardInputData : IDynamic
    {
        //members
        private bool[] _keysPressed;
        private bool[] _keysPressedLast;
        private bool[] _buttonsPressed;
        private bool[] _buttonsPressedLast;
        private float _mouseScroll;
        private float _mouseScrollLast;

        //properties
        public bool[] KeysPressed { get { return _keysPressed; } }
        public bool[] KeysPressedLast { get { return _keysPressedLast; } }
        public bool[] ButtonsPressed { get { return _buttonsPressed; } }
        public bool[] ButtonsPressedLast { get { return _buttonsPressedLast; } }
        public float MouseScroll { get { return _mouseScroll; } }
        public float MouseScrollLast { get { return _mouseScrollLast; } }

        //constructors
        public KeyboardInputData()
        {
            _keysPressed = new bool[255];
            _keysPressedLast = new bool[255];
            _buttonsPressed = new bool[3];
            _buttonsPressedLast = new bool[3];
            _mouseScroll = 0.0f;
            _mouseScrollLast = 0.0f;
        }

        //public methods
        public void update(float dt)
        {
            updateKeyboard();
            updateMouse();
        }

        //private methods
        private void updateKeyboard()
        {
            _keysPressedLast = _keysPressed;
            _keysPressed = new bool[255];
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            
            for (int i = 0; i < keys.Length; i++)
            {
                _keysPressed[(int)keys[i]] = true;
            }
        }

        private void updateMouse()
        {
            _mouseScrollLast = _mouseScroll;
            _mouseScroll = Mouse.GetState().ScrollWheelValue;
            _buttonsPressedLast = _buttonsPressed;
            _buttonsPressed = new bool[3];

            if (Mouse.GetState().LeftButton == ButtonState.Pressed) { _buttonsPressed[(int)MouseButton.LEFT] = true; }
            if (Mouse.GetState().MiddleButton == ButtonState.Pressed) { _buttonsPressed[(int)MouseButton.MIDDLE] = true; }
            if (Mouse.GetState().RightButton == ButtonState.Pressed) { _buttonsPressed[(int)MouseButton.RIGHT] = true; }
        }
    }
}
