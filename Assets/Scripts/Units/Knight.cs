using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseUnit
{
    public override List<Vector2> AttackRange()
    {
        throw new System.NotImplementedException();
    }

    public override List<Vector2> MoveRange()
    {
        var moveList = new List<Vector2>();
        var fromPos = new Vector2(this.transform.position.x, this.transform.position.y);
        for (int i = 1; i <= 2; i++)
        {
            for (int j = 1; j <= 2; j++)
            {
                if (i != j)
                {
                    if (fromPos.x + i < 8 && fromPos.y + j < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + i, fromPos.y + j)).OccupiedUnit == null)
                    {
                        moveList.Add(new Vector2(fromPos.x + i, fromPos.y + j));
                    }
                    if (fromPos.x + i < 8 && fromPos.y - j >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + i, fromPos.y - j)).OccupiedUnit == null)
                    {
                        moveList.Add(new Vector2(fromPos.x + i, fromPos.y - j));
                    }
                    if (fromPos.x - i >= 0 && fromPos.y + j < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - i, fromPos.y + j)).OccupiedUnit == null)
                    {
                        moveList.Add(new Vector2(fromPos.x - i, fromPos.y + j));
                    }
                    if (fromPos.x - i >= 0 && fromPos.y - j >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - i, fromPos.y - j)).OccupiedUnit == null)
                    {
                        moveList.Add(new Vector2(fromPos.x - i, fromPos.y - j));
                    }
                }
            }
        }
        return moveList;
    }
}
