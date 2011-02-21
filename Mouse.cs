using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;
using OpenTK.Input;

namespace FireflyGLTest {

	class Mouse : IUpdatable {

		bool mouseDown = false;
		bool started = false;

		public Mouse () {

			Firefly.AddToUpdateList( this );
		}

		#region IUpdatable Members

		public void Update () {

			Firefly.Window.GameWindow.Mouse.ButtonDown += new EventHandler<MouseButtonEventArgs>( Mouse_ButtonDown );
			Firefly.Window.GameWindow.Mouse.ButtonUp += new EventHandler<MouseButtonEventArgs>( Mouse_ButtonUp );
			Firefly.Window.GameWindow.Keyboard.KeyDown += new EventHandler<KeyboardKeyEventArgs>( Keyboard_KeyDown );
		}

		void Keyboard_KeyDown ( object sender, KeyboardKeyEventArgs e ) {

			if ( started ) return;
			if ( e.Key == Key.F9 ) return;
			started = true;
			for ( int i = 0 ; i < 200 ; ++i ) {
				new Particle( 400, 250 );
			}
		}

		void Mouse_ButtonDown ( object sender, MouseButtonEventArgs e ) {

			mouseDown = true;
		}

		void Mouse_ButtonUp ( object sender, MouseButtonEventArgs e ) {

			if ( !mouseDown ) return;
			mouseDown = false;
			new Tile( e.X, e.Y );
			Console.WriteLine( e.X );
		}

		#endregion
	}
}
