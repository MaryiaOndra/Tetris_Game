namespace Application.Models
{
    sealed class PlayField 
    {
        private int posX = PlayFieldConst.BorderXPos;
        private int posY = PlayFieldConst.BorderYPos;
        private char fieldChar = PlayFieldConst.SymBorder;

        public Point[] RightSide { get; private set; }
        public Point[] LeftSide { get; private set; }
        public Point[] BottomSide { get; private set; }
        public Point[][] Points { get; internal set; }

        public PlayField()
        {
            DrawLeftSide();

            DrawRightSide();

            DrawBottomSide();
        }

        internal void DrawLeftSide()
        {
            LeftSide = new Point[PlayFieldConst.FieldHeight];

            for (int i = 0; i < PlayFieldConst.FieldHeight; i++)
            {
                LeftSide[i] = new Point(posX, posY, fieldChar);
                LeftSide[i].Draw();
                posY++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }

        internal void DrawRightSide()
        {
            RightSide = new Point[PlayFieldConst.FieldHeight];

            for (int i = 0; i < PlayFieldConst.FieldHeight; i++)
            {
                RightSide[i] = new Point((posX + PlayFieldConst.FieldWidth), posY, fieldChar);
                RightSide[i].Draw();
                posY++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }

        internal void DrawBottomSide()
        {
            BottomSide = new Point[PlayFieldConst.FieldWidth + 1];

            for (int i = 0; i < PlayFieldConst.FieldWidth + 1; i++)
            {
                BottomSide[i] = new Point(posX, (posY + PlayFieldConst.FieldHeight), fieldChar);
                BottomSide[i].Draw();
                posX++;
            }

            posX = PlayFieldConst.BorderXPos;
            posY = PlayFieldConst.BorderYPos;
        }
    }
}
