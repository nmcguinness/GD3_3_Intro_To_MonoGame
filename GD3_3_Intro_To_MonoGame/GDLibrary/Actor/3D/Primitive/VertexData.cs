using GDLibrary.Type;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GDLibrary.Actor
{
    public class VertexData<T> :
        IDeepCloneable, IVertexData where T : struct, IVertexType
    {
        private T[] vertices;
        private PrimitiveType primitiveType;
        private int primitiveCount;

        //TODO - get set?
        private int vertexOffset;

        public VertexData(PrimitiveType primitiveType, T[] vertices,
            int vertexOffset, int primitiveCount)
        {
            this.primitiveType = primitiveType;
            this.vertices = vertices;

            this.vertexOffset = vertexOffset;
            this.primitiveCount = primitiveCount;
        }

        public object Clone()
        {
            return this;
        }

        public object DeepClone()
        {
            return new VertexData<T>(primitiveType, vertices, vertexOffset,
                primitiveCount);
        }

        public void Draw(GameTime gameTime, BasicEffect effect)
        {
            effect.GraphicsDevice.DrawUserPrimitives<T>(
                   this.primitiveType,
                   vertices, this.vertexOffset, this.primitiveCount);
        }

        public int GetPrimitiveCount()
        {
            return this.primitiveCount;
        }

        public PrimitiveType GetPrimitiveType()
        {
            return this.primitiveType;
        }

        public void SetPrimitiveCount(int primitiveCount)
        {
            this.primitiveCount
                = primitiveCount <= 0 ? 0 : primitiveCount;
        }

        public void SetPrimitiveType(PrimitiveType primitiveType)
        {
            this.primitiveType = primitiveType;
        }
    }
}