using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;
using OpenTK.Input;

namespace FireflyGLTest {

	class Mouse : IUpdatable {

		bool mouseDown = false;
		bool keyDown = false;
		bool started = false;

		public Mouse () {

			Firefly.AddToUpdateList( this );
		}

		#region IUpdatable Members

		public void Update () {

			Firefly.Window.GameWindow.Mouse.ButtonDown += new EventHandler<MouseButtonEventArgs>( Mouse_ButtonDown ); //TODO: Wrap input
			Firefly.Window.GameWindow.Mouse.ButtonUp += new EventHandler<MouseButtonEventArgs>( Mouse_ButtonUp );
			Firefly.Window.GameWindow.Keyboard.KeyDown += new EventHandler<KeyboardKeyEventArgs>( Keyboard_KeyDown );
			Firefly.Window.GameWindow.Keyboard.KeyUp += new EventHandler<KeyboardKeyEventArgs>( Keyboard_KeyUp );
		}

		void Keyboard_KeyUp ( object sender, KeyboardKeyEventArgs e ) {

			keyDown = false;
		}

		void Keyboard_KeyDown ( object sender, KeyboardKeyEventArgs e ) {

			if ( keyDown ) return;
			if ( !keyDown )
				keyDown = true;

			if ( e.Key == Key.F9 ) return;
			if ( e.Key == Key.Left ) {
				Camera.CurrentCamera.Rotation -= 0.01F;
				return;
			}
			if ( e.Key == Key.Right ) {
				Camera.CurrentCamera.X -= 20;
				return;
			}
			if ( started ) return;
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
