using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;

namespace FireflyGLTest {

	class Mouse : IUpdatable {

		bool started = false;

		public Mouse () {

			Firefly.AddToUpdateList( this );
		}

		#region IUpdatable Members

		public void Update () {

			//TODO: Wrap input
			if ( Input.Keys[ Key.Space ] == InputState.Click ) {
				for ( int i = 0 ; i < 200 ; ++i ) {
					new Particle( 400, 250 );
				}
			}
			if ( Input.Keys[ Key.Left ] == InputState.Down ) {
				Camera.CurrentCamera.X += 3;
			}
			if ( Input.Keys[ Key.Right ] == InputState.Down ) {
				Camera.CurrentCamera.X -= 3;
			}
			if ( Input.Keys[ Key.Up ] == InputState.Down ) {
				Camera.CurrentCamera.Y += 3;
			}
			if ( Input.Keys[ Key.Down ] == InputState.Down ) {
				Camera.CurrentCamera.Y -= 3;
			}
			if ( Input.MouseButtons[ MouseButton.Left ] == InputState.Click ) {
				new Tile( Input.MouseX, Input.MouseY );
			}
		}

		#endregion
	}
}
