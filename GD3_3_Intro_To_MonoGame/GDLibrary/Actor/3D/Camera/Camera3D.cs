using Microsoft.Xna.Framework;

namespace GDLibrary.Actor
{
    //TODO
    public class Camera3D
    {
        private Matrix view;
        private Matrix projection;

        public Matrix View { get => view; set => view = value; }
        public Matrix Projection { get => projection; set => projection = value; }

        //TODO - What parameters should the camera accept?
        /// <summary>
        /// Instanciate a 3D camera
        /// </summary>
        //public Camera3D()
        //{
        //}
    }
}