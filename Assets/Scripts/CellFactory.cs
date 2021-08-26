using UnityEngine;
using DG.Tweening;

public class CellFactory : MonoBehaviour
{
    [SerializeField] private LevelProperties _levelProperties;
    [SerializeField] private CellEventHandler _cellEventHandler;

    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private Transform _rowContainer;
    [SerializeField] private GameObject _cellPrefab;

    [SerializeField] private int _cellInRowCount;

    public GameObject[] Rows { get; set; }
    public GameObject[] Cells { get; set; }

    private void Start()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].transform.DOShakeScale(1);
        }
    }

    public void SpawnCells(LetterData[] letterDatas)
    {
        int rowCount = _levelProperties.GetLetterCount / _cellInRowCount;
        var rows = new GameObject[rowCount];
        var cells = new GameObject[letterDatas.Length];

        for (int i = 0; i < rowCount; i++)
        {
            rows[i] = Instantiate(_rowPrefab, _rowContainer);
        }

        Rows = rows;

        for (int i = 0; i < letterDatas.Length; i++)
        {
            var cellPrefab = Instantiate(_cellPrefab, rows[Mathf.RoundToInt(i % rowCount)].transform);
            cells[i] = cellPrefab;
            var cell = cellPrefab.GetComponent<Cell>();
            cell.Init(letterDatas[i]);

            if (letterDatas[i].Letter == _levelProperties.CurrentLetter)
            {
                cell.OnCellTaped += _cellEventHandler.OnRightCellTaped;
            }
            else
            {
                cell.OnCellTaped += _cellEventHandler.OnWrongCellTaped;
            }
        }

        Cells = cells;
    }

    public void ClearGrid()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Destroy(Cells[i]);
        }

        for (int i = 0; i < Rows.Length; i++)
        {
            Destroy(Rows[i]);
        }
    }
}
