using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlack : BaseUnit
{
    public abstract override List<Vector2> MoveRange();
    public abstract override List<Vector2> AttackRange();

}
