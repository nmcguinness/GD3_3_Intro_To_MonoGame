using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GDLibrary.Type
{
    /// <summary>
    /// Parent interface for all vertex data objects
    /// </summary>
    public interface IVertexData : ICloneable
    {
        void Draw(GameTime gameTime, BasicEffect effect);

        PrimitiveType GetPrimitiveType();

        int GetPrimitiveCount();

        void SetPrimitiveType(PrimitiveType primitiveType);

        void SetPrimitiveCount(int primitiveCount);
    }
}