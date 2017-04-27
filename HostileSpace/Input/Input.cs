using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostileSpace
{
    class Input : GameComponent
    {
        GameKeyboard keyboard;
        GameMouse mouse;


        public Input(HostileSpace Game)
            : base(Game)
        {
            keyboard = new GameKeyboard(Game);
            mouse = new GameMouse(Game);
        }


        public override void Update(int Elapsed)
        {
            keyboard.Update(Elapsed);
            mouse.Update(Elapsed);
        }


        public GameKeyboard Keyboard
        {
            get { return keyboard; }
        }

        public GameMouse Mouse
        {
            get { return mouse; }
        }


    }
}
