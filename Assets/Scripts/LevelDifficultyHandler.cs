using UnityEngine;

public class LevelDifficultyHandler : MonoBehaviour
{
    [SerializeField] private LevelProperties _levelProperties;
    [SerializeField] private ContentRandomizer _contentRandomizer;
    [SerializeField] private TaskHandler _taskHandler;
    [SerializeField] private RestartHandler _restartHandler;
    [SerializeField] private CellFactory _cellFactory;

    public void ChangeDifficulty()
    {
        if (_levelProperties.CurrentDifficulty.NextLevelDifficultyType == LevelDifficultyType.Easy)
        {
            _restartHandler.SpawnPanel();
            return;
        }
        _cellFactory.ClearGrid();
        _contentRandomizer.FillRemainingLists();
        _levelProperties.UpdateDifficultyData(_levelProperties.CurrentDifficulty.NextLevelDifficultyType);
        Init();
    }

    public void Init()
    {
        var letters = _contentRandomizer.GetRandomLetters();
        var letter = _contentRandomizer.ChooseRandomLetter(letters);
        _levelProperties.CurrentLetter = letter.Letter;
        _taskHandler.UpdateTaskText(letter.Letter);
        _cellFactory.SpawnCells(letters);
    }
}
