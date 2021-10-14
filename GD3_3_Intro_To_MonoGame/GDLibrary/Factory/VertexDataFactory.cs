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

                    case VertexDataType.WireframeRectangle;
                        vertexData = GetWireframeRectangleData();
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

            return new VertexData<VertexPositionColor>(vertices,
                 PrimitiveType.LineList, 1, 0);
        }

        private static IVertexData GetOriginData()
        {
            throw new NotImplementedException();
        }

        private static IVertexData GetWireframeRectangleData()
        {
            throw new NotImplementedException();
        }

        private static IVertexData GetWireframeCircleData()
        {
            throw new NotImplementedException();
        }

        private static IVertexData GetWireframeCubeData()
        {
            throw new NotImplementedException();
        }

        #endregion Get Vertex Data for each primitive
    }
}