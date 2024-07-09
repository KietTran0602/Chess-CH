using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    public int Hp;
    public int Dmg;
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;
    public PieceName pieceName;

    public abstract List<Vector2> MoveRange();
    public abstract List<Vector2> AttackRange();

    public void TakeDmg(int amount)
    {
        Hp -= amount;
    }
    public void DealDmg(BaseUnit unit)
    {

        if (unit != null)
        {
            unit.TakeDmg(Dmg);
        }
    }
}


