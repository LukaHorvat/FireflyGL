using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace FireflyGL {

	class Camera {

		private static Matrix4 cameraMatrix;
		public static Matrix4 CameraMatrix {
			get { return cameraMatrix; }
			set { cameraMatrix = value; }
		}

		private Matrix4 matrix;
		public Matrix4 Matrix {
			get { return matrix; }
			set { throw new Exception( "Can't change the camera matrix directly. Use the X and Y properties" ); }
		}

		private float x, y;
		public float Y {
			get { return y; }
			set {
				y = value;
				matrix.Row3.Y = y;
			}
		}
		public float X {
			get { return x; }
			set {
				x = value;
				matrix.Row3.X = x;
			}
		}

		static Camera () {

			cameraMatrix = Matrix4.Identity;
		}

		public Camera () {

			matrix = Matrix4.Identity;
		}

		public void Activate () {

			cameraMatrix = matrix;
		}
	}
}
