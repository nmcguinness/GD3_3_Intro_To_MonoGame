using GDLibrary.Actor;
using GDLibrary.Type;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GDLibrary.Factory
{
    //TODO - Add code to generate more vertex data types
    /// <summary>
    /// Provides common vertex data for 3D primitives and caches the vertex data returned in a dictionary for later re-use
    ///
    /// Note, a sealed class simply means that we never intend to inherit from this class
    /// e.g. We will never do something like...
    /// class MyBetterVertexFactory : VertexFactory
    /// </summary>
    /// <see cref="GDLibrary.Main"/>
    public sealed class VertexDataFactory
    {
        #region Member Variables

        /// <summary>
        /// a dictionary (e.g. HashMap in Java) that stores a reference to any new vertex data object for efficient re-use
        /// </summary>
        private static Dictionary<VertexDataType, IVertexData>
            vertexDataDictionary
            = new Dictionary<VertexDataType, IVertexData>();

        #endregion Member Variables

        /// <summary>
        /// Tests if the vertexDataType specified is in the dictionary
        /// </summary>
        /// <param name="vertexDataType"></param>
        /// <returns>True if the dictionary contains this type, otherwise false</returns>
        public static bool Exists(VertexDataType vertexDataType)
        {
            return vertexDataDictionary.ContainsKey(vertexDataType);
        }

        /// <summary>
        /// Returns either a new instance, or a dictionary cached instance, of vertex data based on VertexDataType specified
        /// </summary>
        /// <param name="vertexDataType"></param>
        /// <returns>Reference to IVertexData for type specified</returns>
        public static IVertexData Get(VertexDataType vertexDataType)
        {
            if (!vertexDataDictionary.ContainsKey(vertexDataType))
            {
                IVertexData vertexData = null;

                switch (vertexDataType)
                {
                    case VertexDataType.Line:
                        vertexData = GetLineData();
                        break;

                    case VertexDataType.WireframeRectangle:
                        vertexData = GetWireframeRectangleData();
                        break;

                    case VertexDataType.FilledTriangle:
                        vertexData = GetFilledTriangleData();
                        break;

                    //TODO - Add more (1) VertexDataTypes and (2) method to return the IVertexData

                    default:
                        break;
                }

                if (vertexData != null)
                    vertexDataDictionary.Add(vertexDataType, vertexData);
            }

            return vertexDataDictionary[vertexDataType];
        }

        private static IVertexData GetFilledTriangleData()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[3];

            //apex
            vertices[0] = new VertexPositionColor(
                new Vector3(0, 1, 0), Color.Red);

            //bottom right
            vertices[1] = new VertexPositionColor(
                new Vector3(1, 0, 0), Color.Green);

            //bottom left
            vertices[2] = new VertexPositionColor(
                new Vector3(-1, 0, 0), Color.Blue);

            return new VertexData<VertexPositionColor>(
                PrimitiveType.TriangleList, vertices,
                0, 1);
        }

        #region Get Vertex Data for each primitive

        /// <summary>
        /// Returns an IVertexData object containing the vertex data (position, color) for a white line along the -ve and +ve X-axis with total length 2 units
        /// </summary>
        /// <returns>IVertexData for a white line</returns>
        private static IVertexData GetLineData()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[2];

            vertices[0] = new VertexPositionColor(-Vector3.UnitX, Color.White);
            vertices[1] = new VertexPositionColor(Vector3.UnitX, Color.White);

            return new VertexData<VertexPositionColor>(PrimitiveType.LineList, vertices,
                             0, 1);
        }

        private static IVertexData GetOriginData()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[20];

            //x-axis
            vertices[0] = new VertexPositionColor(-Vector3.UnitX, Color.DarkRed);
            vertices[1] = new VertexPositionColor(Vector3.UnitX, Color.DarkRed);

            //y-axis
            vertices[2] = new VertexPositionColor(-Vector3.UnitY, Color.DarkGreen);
            vertices[3] = new VertexPositionColor(Vector3.UnitY, Color.DarkGreen);

            //z-axis
            vertices[4] = new VertexPositionColor(-Vector3.UnitZ, Color.DarkBlue);
            vertices[5] = new VertexPositionColor(Vector3.UnitZ, Color.DarkBlue);

            //to do - x-text , y-text, z-text
            //x label
            vertices[6] = new VertexPositionColor(new Vector3(1.1f, 0.1f, 0), Color.DarkRed);
            vertices[7] = new VertexPositionColor(new Vector3(1.3f, -0.1f, 0), Color.DarkRed);
            vertices[8] = new VertexPositionColor(new Vector3(1.3f, 0.1f, 0), Color.DarkRed);
            vertices[9] = new VertexPositionColor(new Vector3(1.1f, -0.1f, 0), Color.DarkRed);

            //y label
            vertices[10] = new VertexPositionColor(new Vector3(-0.1f, 1.3f, 0), Color.DarkGreen);
            vertices[11] = new VertexPositionColor(new Vector3(0, 1.2f, 0), Color.DarkGreen);
            vertices[12] = new VertexPositionColor(new Vector3(0.1f, 1.3f, 0), Color.DarkGreen);
            vertices[13] = new VertexPositionColor(new Vector3(-0.1f, 1.1f, 0), Color.DarkGreen);

            //z label
            vertices[14] = new VertexPositionColor(new Vector3(0, 0.1f, 1.1f), Color.DarkBlue);
            vertices[15] = new VertexPositionColor(new Vector3(0, 0.1f, 1.3f), Color.DarkBlue);
            vertices[16] = new VertexPositionColor(new Vector3(0, 0.1f, 1.1f), Color.DarkBlue);
            vertices[17] = new VertexPositionColor(new Vector3(0, -0.1f, 1.3f), Color.DarkBlue);
            vertices[18] = new VertexPositionColor(new Vector3(0, -0.1f, 1.3f), Color.DarkBlue);
            vertices[19] = new VertexPositionColor(new Vector3(0, -0.1f, 1.1f), Color.DarkBlue);

            return new VertexData<VertexPositionColor>(PrimitiveType.LineList, vertices,
                             0, 10);
        }

        private static IVertexData GetWireframeRectangleData()
        {
            VertexPositionColor[] vertices
                = new VertexPositionColor[5];

            //top left vertex
            vertices[0] = new VertexPositionColor(
                new Vector3(-0.5f, 0.5f, 0), Color.White);

            //top right vertex
            vertices[1] = new VertexPositionColor(
                new Vector3(0.5f, 0.5f, 0), Color.White);

            //bottom right vertex
            vertices[2] = new VertexPositionColor(
                new Vector3(0.5f, -0.5f, 0), Color.White);

            //bottom left vertex
            vertices[3] = new VertexPositionColor(
                new Vector3(-0.5f, -0.5f, 0), Color.White);

            //top left vertex to close the rectangle
            vertices[4] = new VertexPositionColor(
                new Vector3(-0.5f, 0.5f, 0), Color.White);

            return new VertexData<VertexPositionColor>(
                PrimitiveType.LineStrip, vertices,
                0, 4);
        }

        private static IVertexData GetWireframeCubeData()
        {
            throw new NotImplementedException();
            /////a cube has 12 lines so 24 verts
            //VertexPositionColor[] vertices
            //    = new VertexPositionColor[24];

            //float halfSize = 0.5f;
            ////top

            ////left
            //vertices[0] = new VertexPositionColor(
            //    new Vector3(-halfSize, halfSize, -halfSize),
            //    Color.White);

            //bottom

            //sides
        }

        //public static IVertexData GetWireframeCircleData()
        //{
        //    int radius = 1;
        //    int sweepAngleInDegrees = 45;

        //    //sweep angle should also be >= 1 and a multiple of 360
        //    //if angle is not a multiple of 360 the circle will not close - remember we are drawing with a LineStrip
        //    if ((sweepAngleInDegrees < 1) || (360 % sweepAngleInDegrees != 0))
        //    {
        //        return null;
        //    }

        //    //number of segments forming the circle (e.g. for sweepAngleInDegrees == 90 we have 4 segments)
        //    int segmentCount = 360 / sweepAngleInDegrees;

        //    //segment angle
        //    float rads = MathHelper.ToRadians(sweepAngleInDegrees);

        //    //we need one more vertex to close the circle (e.g. 4 + 1 vertices to draw four lines)
        //    VertexPositionColor[] vertices = new VertexPositionColor[segmentCount + 1];

        //    float a, b;

        //    for (int i = 0; i < vertices.Length; i++)
        //    {
        //        //round the values so we dont end up with the two oordinate values very close to but not equals to 0
        //        a = (float)(radius * Math.Round(Math.Cos(rads * i), 2));
        //        b = (float)(radius * Math.Round(Math.Sin(rads * i), 2));

        //        vertices[i] = new VertexPositionColor(new Vector3(a, b, 0), Color.White);
        //    }

        //    return new VertexData<VertexPositionColor>(PrimitiveType.LineStrip, vertices,
        //                   0, vertices.Length - 1);
        //}

        #endregion Get Vertex Data for each primitive
    }
}