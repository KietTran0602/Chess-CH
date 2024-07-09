using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _selectedobj, _tileobj, _tileUnitobj, _gameStateobj;
    public static MenuManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void showSelected(BaseUnit unit)
    {
        if (unit == null)
        {
            _selectedobj.SetActive(false);
            return;
        }
        _selectedobj.GetComponentInChildren<TextMeshProUGUI>().text = unit.UnitName;
        _selectedobj.SetActive(true);
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _tileobj.SetActive(false);
            _tileUnitobj.SetActive(false);
            return;
        }
        else
        {
            _tileobj.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
            _tileobj.SetActive(true);
        }


        if (tile.OccupiedUnit)
        {
            _tileobj.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupiedUnit.UnitName;
            _tileobj.SetActive(true);
        }
    }

    public void showGamestateinfo()
    {
        if (GameManager.Instance.State == null)
        {
            _gameStateobj.SetActive(false);
        }
        _gameStateobj.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.State.ToString();
        _gameStateobj.SetActive(true);
    }
}
