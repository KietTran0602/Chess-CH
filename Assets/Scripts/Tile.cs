using Assets.Scripts.Units.Black;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] public GameObject _highlight;
    [SerializeField] public GameObject _movehighlight;
    [SerializeField] public GameObject _attackhighlight;


    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool walkable => _isWalkable && OccupiedUnit == null;
    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
        if (this.OccupiedUnit != null && this.OccupiedUnit.Faction == Faction.black && this.OccupiedUnit.pieceName == PieceName.Pawn)
        {
            var unit = (PawnB)this.OccupiedUnit;
            unit.HpText.SetActive(true);

            unit.DmgText.SetActive(true);
            foreach (var item in unit.GetComponents<TextMeshPro>())
            {
                Debug.Log(item.name);

            }
            //switch (unit.GetComponent<TextMeshPro>().name)
            //{
            //    case "Hp":
            //        unit.GetComponent<TextMeshPro>().text = this.OccupiedUnit.Hp.ToString();

            //        break;
            //    case "Dmg":
            //        unit.GetComponent<TextMeshPro>().text = this.OccupiedUnit.Dmg.ToString();

            //        break;
            //}


        }
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }
    public void setUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null)
        {
            unit.OccupiedTile.OccupiedUnit = null;
        }
        unit.transform.position = transform.position;

        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
    public void OnMoveHighlight(BaseUnit unit)
    {
        foreach (var tileEntry in GridManager.Instance.GetAllTile())
        {
            var currentTile = tileEntry.Value;
            if (unit.MoveRange().Contains(tileEntry.Key))
            {
                currentTile._movehighlight.SetActive(true);
            }
            else
            {
                currentTile._movehighlight.SetActive(false);
            }

        }
    }
    public void OnAttackHighlight(BaseUnit unit)
    {
        foreach (var tileEntry in GridManager.Instance.GetAllTile())
        {
            var currentTile = tileEntry.Value;
            if (unit.AttackRange().Contains(tileEntry.Key))
            {
                currentTile._attackhighlight.SetActive(true);
            }
            else
            {
                currentTile._attackhighlight.SetActive(false);
            }

        }
    }
    public void OffMoveHighlight()
    {
        foreach (KeyValuePair<Vector2, Tile> tileEntry in GridManager.Instance.GetAllTile())
        {
            Tile currentTile = tileEntry.Value;
            currentTile._movehighlight.SetActive(false);
            currentTile._attackhighlight.SetActive(false);

        }
    }
    private void OnMouseDown()
    {

        switch (GameManager.Instance.State)
        {
            case (GameState.WhiteTurn):
                if (OccupiedUnit != null && OccupiedUnit.Faction == Faction.white)
                {
                    var unit = UnitManager.Instance.SetSelectedUnit(OccupiedUnit);
                    OnMoveHighlight(unit);
                    OnAttackHighlight(unit);
                }
                else if (UnitManager.Instance.SelectedUnit != null)
                {
                    if (this.OccupiedUnit == null)
                    {
                        Debug.Log("Move");
                        MovePiece(UnitManager.Instance.SelectedUnit, GameState.BlackTurn);
                    }
                    else if (this.OccupiedUnit.Faction == Faction.black)
                    {
                        AttackPiece(UnitManager.Instance.SelectedUnit, GameState.BlackTurn);

                    }
                    OffMoveHighlight();
                }
                break;
            case (GameState.BlackTurn):
                if (OccupiedUnit != null && OccupiedUnit.Faction == Faction.black)
                {
                    var unit = UnitManager.Instance.SetSelectedUnit(OccupiedUnit);
                    OnMoveHighlight(unit);
                    OnAttackHighlight(unit);

                }
                else if (UnitManager.Instance.SelectedUnit != null)
                {
                    if (this.OccupiedUnit == null)
                    {
                        Debug.Log("Move");
                        MovePiece(UnitManager.Instance.SelectedUnit, GameState.WhiteTurn);
                    }
                    else if (this.OccupiedUnit.Faction == Faction.white)
                    {
                        AttackPiece(UnitManager.Instance.SelectedUnit, GameState.WhiteTurn);
                    }
                    OffMoveHighlight();
                }
                break;
        }
    }

    public void MovePiece(BaseUnit unit, GameState newGameState)
    {
        switch (unit.pieceName)
        {
            case PieceName.Pawn:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            case PieceName.Rook:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            case PieceName.Bishop:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            case PieceName.Knight:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            case PieceName.Queen:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            case PieceName.King:
                if (unit.MoveRange().Contains(this.transform.position))
                {
                    setUnit(unit);
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            default:
                break;
        }
        UnitManager.Instance.SetSelectedUnit(null);
    }

    public void AttackPiece(BaseUnit unit, GameState newGameState)
    {
        switch (unit.pieceName)
        {
            case PieceName.Pawn:
                if (unit.AttackRange().Contains(this.transform.position))
                {
                    var enemy = GridManager.Instance.GetTileAtPosotion(this.transform.position).OccupiedUnit;
                    unit.DealDmg(enemy);
                    Debug.Log(enemy.Hp);
                    if (enemy.Hp <= 0)
                    {
                        Destroy(enemy.gameObject);
                        setUnit(unit);
                    }
                    OffMoveHighlight();
                    GameManager.Instance.updateGameState(newGameState);
                }
                break;
            default:
                break;
        }
    }
}
