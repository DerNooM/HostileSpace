using System;
using SFML.Window;


namespace HostileSpace.Utils
{
    class KeyboardState : GameObject
    {


        public KeyboardState(HostileSpace Game)
            : base(Game)
        {
            Game.RenderWindow.TextEntered += RenderWindow_TextEntered;
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

            if (e.Unicode[0] == 32)
                SpacePressed?.Invoke(this, null);
        }


        public event EventHandler<KeyPressedArgs> KeyPressed;
        public event EventHandler BackspacePressed;
        public event EventHandler EnterPressed;
        public event EventHandler SpacePressed;
        public event EventHandler TabulatorPressed;

        public class KeyPressedArgs : EventArgs
        {
            public Char Char { get; set; }
        }


    }
}
