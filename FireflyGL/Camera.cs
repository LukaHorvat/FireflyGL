using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace FireflyGL {

	class Camera {

		static Camera currentCamera;
		public static Camera CurrentCamera {
			get { return Camera.currentCamera; }
			set { Camera.currentCamera = value; }
		}

		public static Matrix4 CameraMatrix {
			get { return currentCamera.Matrix; }
		}

		private DisplayObject matrixManager; //We use the DisplayObject class as a matrix holder
		private Matrix4 finalMatrix;
		private bool requiresUpdate = false;

		public float Rotation {
			get { return matrixManager.Rotation; }
			set { matrixManager.Rotation = value; requiresUpdate = true; }
		}
		public float X {
			get { return matrixManager.X; }
			set { matrixManager.X = value; requiresUpdate = true; } //TODO: Wrap GameWindow
		}
		public float Y {
			get { return matrixManager.Y; }
			set { matrixManager.Y = value; requiresUpdate = true; }
		}
		public float Zoom {
			get { return matrixManager.ScaleX; }
			set {
				matrixManager.ScaleX = value;
				matrixManager.ScaleY = value;
				requiresUpdate = true;
			}
		}
		public Matrix4 Matrix {
			get {
				if ( requiresUpdate ) {
					requiresUpdate = false;
				}
				return finalMatrix;
			}
		}

		public Camera () {

			matrixManager = new DisplayObject();
		}

		public void Activate () {

			currentCamera = this;
		}//TODO: Rewrite Camera class
	}
}
