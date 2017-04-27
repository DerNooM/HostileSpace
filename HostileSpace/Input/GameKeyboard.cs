using System;
using SFML.Window;

namespace HostileSpace
{
    class GameKeyboard : GameComponent
    {
        Boolean f12Down = false;


        public GameKeyboard(HostileSpace Game)
            : base(Game)
        {
            Game.Window.TextEntered += RenderWindow_TextEntered;
        }


        public override void Update(Int32 Elapsed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.F12))
            {
                f12Down = true;
            }
            else
            {
                if (f12Down)
                {
                    F12Pressed?.Invoke(this, null);
                }
                f12Down = false;
            }
        }

        private void RenderWindow_TextEntered(object sender, TextEventArgs e)
        {
            //Console.WriteLine((int)e.Unicode[0]);

            if (e.Unicode[0] >= 48 && e.Unicode[0] <= 57)
            {
                KeyPressed?.Invoke(this, new KeyPressedArgs() { Char = e.Unicode[0] });
            }
            else if (e.Unicode[0] >= 65 && e.Unicode[0] <= 90)
            {
                KeyPressed?.Invoke(this, new KeyPressedArgs() { Char = e.Unicode[0] });
            }
            else if (e.Unicode[0] >= 97 && e.Unicode[0] <= 122)
            {
                KeyPressed?.Invoke(this, new KeyPressedArgs() { Char = e.Unicode[0] });
            }

            if (e.Unicode[0] == 8)
                BackspacePressed?.Invoke(this, null);

            if (e.Unicode[0] == 9)
                TabulatorPressed?.Invoke(this, null);

            if (e.Unicode[0] == 13)
                EnterPressed?.Invoke(this, null);

            if (e.Unicode[0] == 27)
                EscapePressed?.Invoke(this, null);

            if (e.Unicode[0] == 32)
                SpacePressed?.Invoke(this, null);
        }


        public event EventHandler BackspacePressed;
        public event EventHandler TabulatorPressed;
        public event EventHandler EnterPressed;
        public event EventHandler EscapePressed;
        public event EventHandler SpacePressed;
        
        public event EventHandler F12Pressed;

        public event EventHandler<KeyPressedArgs> KeyPressed;

        public class KeyPressedArgs : EventArgs
        {
            public Char Char { get; set; }
        }


    }
}
