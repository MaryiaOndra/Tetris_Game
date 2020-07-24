using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Shapes
{
    abstract class Shapes
    {
        protected int x = PlayFieldConst.BorderXPos + PlayFieldConst.FieldWidth / 2;
        protected int y = PlayFieldConst.BorderYPos;
        protected char ch = 'M';

        abstract protected void CreateShape();
    }
}
