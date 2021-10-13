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

        public VertexData(T[] vertices, PrimitiveType primitiveType, int primitiveCount, int vertexOffset)
        {
            this.vertices = vertices;
            this.primitiveType = primitiveType;
            this.primitiveCount = primitiveCount;
            this.vertexOffset = vertexOffset;
        }

        public object Clone()
        {
            return this;
        }

        public object DeepClone()
        {
            return new VertexData<T>(vertices, primitiveType,
                primitiveCount, vertexOffset);
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