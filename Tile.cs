using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;

namespace FireflyGLTest {

	class Tile : ColoredShape {

		public static Dictionary<int, Tile> Tiles = new Dictionary<int, Tile>();

		float r, g, b;
		public float B {
			get { return b; }
			set { b = value; }
		}
		public float G {
			get { return g; }
			set { g = value; }
		}
		public float R {
			get { return r; }
			set { r = value; }
		}

		bool isHit;
		public bool IsHit {
			get { return isHit; }
			set { isHit = value; }
		}
		float size = 20;

		public Tile ( int X, int Y ) {

			filledPolygons.AddLast( new Polygon( false,
				0, 0, 0.2F, 0.2F, 0.2F, 1,
				size, 0, 0.2F, 0.2F, 0.2F, 1,
				size, size, 0.2F, 0.2F, 0.2F, 1,
				0, size, 0.2F, 0.2F, 0.2F, 1 ) );
			SetPolygons();

			this.X = (int)( X / size ) * size;
			this.Y = (int)( Y / size ) * size;

			if ( !Tiles.ContainsKey( (int)( this.X / size * ( 800 / size ) + this.Y / size ) ) ) {
				Tiles.Add( (int)( this.X / size * ( 800 / size ) + this.Y / size ), this );
				Firefly.AddToRenderList( this );
			}
		}

		public void Hit ( float R, float G, float B ) {

			if ( isHit ) return;
			isHit = true;
			filledPolygons.Clear();
			filledPolygons.AddLast( new Polygon( false,
				0, 0, R, G, B, 1,
				size, 0, R, G, B, 1,
				size, size, R, G, B, 1,
				0, size, R, G, B, 1 ) );
			SetPolygons();
		}
	}
}
