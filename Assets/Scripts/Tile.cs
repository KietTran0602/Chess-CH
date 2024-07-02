using UnityEngine;

public class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _highlight;

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

    private void OnMouseDown()
    {
        if (OccupiedUnit != null)
        {
            if (GameManager.Instance.State == GameState.WhiteTurn)
            {
                if (OccupiedUnit.Faction == Faction.white)
                {
                    UnitManager.Instance.SetSelectedWhite((BaseWhite)OccupiedUnit);
                }
                else
                {
                    if (UnitManager.Instance.SelectedWhite != null)
                    {
                        var black = (BaseBlack)OccupiedUnit;
                        Destroy(black.gameObject);
                        UnitManager.Instance.SetSelectedWhite(null);
                    }
                }
            }

        }
        else
        {
            if (UnitManager.Instance.SelectedWhite != null)
            {
                setUnit(UnitManager.Instance.SelectedWhite);
                UnitManager.Instance.SetSelectedWhite(null);

            }
        }
    }
}
