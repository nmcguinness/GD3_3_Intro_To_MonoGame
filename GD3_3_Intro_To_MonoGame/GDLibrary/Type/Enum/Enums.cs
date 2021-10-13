namespace GDLibrary.Type
{
    public enum VertexDataType : sbyte
    {
        #region Wireframe - Use when creating VertexPositionColor vertices

        XYZ, Origin, Line,
        WireframeRectangle, WireframeCircle, WireframeCube

        #endregion Wireframe - Use when creating VertexPositionColor vertices

        //TODO - what other primitives can we create?
    }
}