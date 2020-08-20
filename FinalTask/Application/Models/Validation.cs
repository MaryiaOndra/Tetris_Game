using Application.Models.Shapes;
using System.Collections.Generic;

namespace Application.Models
{
    static class Validation
    {
        internal static bool IsHitBottomOrBlock(Block myBlock, List<Point> usedPoints, PlayField playField)
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                for (int j = 0; j < usedPoints.Count; j++)
                {
                    if (myBlock.newBlock[i].Y.Equals(usedPoints[j].Y - 1)
                        && myBlock.newBlock[i].X.Equals(usedPoints[j].X))
                    {
                        answer = true;
                        break;
                    }
                }

                if (myBlock.newBlock[i].Y.Equals(playField.BottomSide[0].Y - 1))
                {
                    answer = true;
                    break;
                }
            }

            return answer;
        }

        internal static bool IsHitLeftSide(Block myBlock, PlayField playField)
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                if (myBlock.newBlock[i].X.Equals(playField.LeftSide[0].X + 1))
                {
                    answer = true;
                }
            }

            return answer;
        }

        internal static bool IsHitRightSide(Block myBlock, PlayField playField)
        {
            bool answer = false;

            for (int i = 0; i < myBlock.newBlock.Count; i++)
            {
                if (myBlock.newBlock[i].X.Equals(playField.RightSide[0].X - 1))
                {
                    answer = true;
                }
            }

            return answer;
        }

        internal static bool IsOver(List<Point> usedPoints)
        {
            bool answer = false;

            for (int i = 0; i < usedPoints.Count; i++)
            {
                if (usedPoints[i].Y.Equals(BlockConst.StartY))
                {
                    answer = true;
                }
            }

            return answer;
        }

        internal static bool IsFullLines(List<Point> usedPoints, out int row)
        {
            bool answer = false;
            int y = PlayFieldConst.FieldHeight;
            int maxCount = PlayFieldConst.FieldWidth - 1;
            int count = 0;
            row = 0;

            for (int i = y; i >= 0; i--)
            {
                foreach (Point p in usedPoints)
                {
                    if (p.Y.Equals(i))
                    {
                        count++;
                        row = i;
                    }
                }

                if (count.Equals(maxCount))
                {
                    answer = true;
                    break;
                }
                else
                    count = 0;
            }

            return answer;
        }
    }
}
