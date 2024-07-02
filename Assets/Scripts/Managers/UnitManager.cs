using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;

    public BaseWhite SelectedWhite;
    public void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnWhite()
    {
        foreach (var unit in _units.Where(u => u.Faction == Faction.white))
        {
            switch (unit.name)
            {
                case "PawnW":
                    for (int i = 0; i < 8; i++)
                    {
                        AsignUnit(i, 1, unit);
                    }
                    break;
                case "RookW":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 0 : 7;
                        AsignUnit(targetX, 0, unit);
                    }
                    break;
                case "BishopW":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 1 : 6;
                        AsignUnit(targetX, 0, unit);
                    }
                    break;
                case "KnightW":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 2 : 5;
                        AsignUnit(targetX, 0, unit);
                    }
                    break;
                case "QueenW":
                    AsignUnit(3, 0, unit);
                    break;
                case "KingW":
                    AsignUnit(4, 0, unit);
                    break;
            }
        }
    }

    public void SpawnBlack()
    {
        foreach (var unit in _units.Where(u => u.Faction == Faction.black))
        {
            switch (unit.name)
            {
                case "PawnB":
                    for (int i = 0; i < 8; i++)
                    {
                        AsignUnit(i, 6, unit);
                    }
                    break;
                case "RookB":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 0 : 7;
                        AsignUnit(targetX, 7, unit);
                    }
                    break;
                case "BishopB":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 1 : 6;
                        AsignUnit(targetX, 7, unit);
                    }
                    break;
                case "KnightB":
                    for (int i = 0; i < 2; i++)
                    {
                        int targetX = i == 0 ? 2 : 5;
                        AsignUnit(targetX, 7, unit);
                    }
                    break;
                case "QueenB":
                    AsignUnit(3, 7, unit);
                    break;
                case "KingB":
                    AsignUnit(4, 7, unit);
                    break;
            }
        }
        GameManager.Instance.updateGameState(GameState.WhiteTurn);
    }

    public void AsignUnit(int targetX, int targetY, ScriptableUnit unit)
    {
        var spawnedPiece = Instantiate(unit.unitPrefab);
        var spawnedTile = GridManager.Instance.GetAllTile().Where(t => t.Key.y == targetY);
        spawnedTile.Where(t => t.Key.x == targetX).First().Value.setUnit(spawnedPiece);
    }
    //Ham get random
    //private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    //{
    //    return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().unitPrefab;
    //}
    public void SetSelectedWhite(BaseWhite white)
    {
        SelectedWhite = white;
        MenuManager.Instance.showSelected(white);
    }
}