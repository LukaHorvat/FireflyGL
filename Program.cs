using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FireflyGL;

namespace FireflyGLTest {
	class Program {

		static void Main ( string[] args ) {

			Firefly.Initialize( 800, 500, "Test", OnLoad, true );
		}

		static void OnLoad ( object Target, EventArgs Arguments ) {

			Firefly.Window.ClearColor = System.Drawing.Color.Black;

			ColoredShape background = new ColoredShape();
			background.FilledPolygons.AddLast( new Polygon( false,
				0, 0, 0.5F, 0.5F, 0.5F, 1,
				800, 0, 0.5F, 0.5F, 0.5F, 1,
				800, 500, 0.5F, 0.5F, 0.5F, 1,
				0, 500, 0.5F, 0.5F, 0.5F, 1 ) );
			background.SetPolygons();
			//Firefly.RenderList.AddLast( background );


			new Mouse();
		}
	}
}
