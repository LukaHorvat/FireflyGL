using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;

namespace FireflyGLTest {

	class Particle : ColoredShape, IUpdatable {

		float xSpeed, ySpeed;
		public float XSpeed {
			get { return xSpeed; }
			set { xSpeed = value; }
		}
		public float YSpeed {
			get { return ySpeed; }
			set { ySpeed = value; }
		}

		float r, g, b;

		public Particle ( int X, int Y )
			: base() {

			float color = Utility.GetRandomF();
			if ( color > 0.75F ) {
				r = 1;
				g = 0;
				b = 0;
			} else if ( color > 0.5F ) {
				r = 0;
				g = 1;
				b = 0;
			} else if ( color > 0.25F ) {
				r = 0;
				g = 0;
				b = 1;
			} else {
				r = 1;
				g = 1;
				b = 0;
			}

			filledPolygons.AddLast( new Polygon( false,
				-2, -2, r, g, b, 1,
				0, -2, r, g, b, 1,
				0, 2, r, g, b, 1,
				-2, 2, r, g, b, 1 ) );
			filledPolygons.AddLast( new Polygon( false,
				-2, -2, r, g, b, 1,
				-10, 0, r, g, b, 0,
				-2, 2, r, g, b, 1 ) );
			SetPolygons();
			Firefly.AddToRenderList( this );
			Firefly.AddToUpdateList( this );

			this.X = X;
			this.Y = Y;

			xSpeed = Utility.GetRandomF() * 6 - 3;
			ySpeed = Utility.GetRandomF() * 6 - 6;
		}

		#region IUpdatable Members

		public void Update () {

			ySpeed += 0.05F;
			X += xSpeed;
			Y += ySpeed;

			float velocity = (float)Math.Sqrt( xSpeed * xSpeed + ySpeed * ySpeed );
			ScaleX = velocity;
			Rotation = (float)Math.Atan2( ySpeed, xSpeed );

			if ( Tile.Tiles.ContainsKey( (int)( X / 20 * 40 + Y / 20 ) ) ) {
				if ( Utility.GetRandomF() > 0.5F ) {
					Tile.Tiles[ (int)( X / 20 * 40 + Y / 20 ) ].Hit( r, g, b );
				}
			}

			if ( X < 0 || X > 800 || Y > 500 ) {
				Firefly.RemoveEntity( this );
				new Particle( 400, 250 );
			}
		}

		#endregion
	}
}
