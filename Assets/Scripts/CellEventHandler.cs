using UnityEngine;
using DG.Tweening;

public class CellEventHandler : MonoBehaviour
{
    [SerializeField] private LevelDifficultyHandler _difficultyHandler;

    public void OnWrongCellTaped(Cell cell)
    {
        cell.transform.DOShakePosition(0.75f, new Vector3(2, 0, 0));
    }

    public void OnRightCellTaped(Cell cell)
    {
        _difficultyHandler.ChangeDifficulty();
    }
}
