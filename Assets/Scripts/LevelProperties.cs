using System;
using System.Linq;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    [SerializeField] private LevelDifficultyType _levelDifficulty;
    [SerializeField] private LetterType _letterType;

    [SerializeField] private DifficultyLevelData[] _difficultyLevelDatas;

    [SerializeField] private LevelDifficultyHandler _difficultyHandler;

    public LevelDifficultyType LevelDifficulty => _levelDifficulty;
    public LetterType LetterType => _letterType;

    public int GetLetterCount => CurrentDifficulty.CellCount;
    public string CurrentLetter { get; set; }

    public DifficultyLevelData CurrentDifficulty => _difficultyLevelDatas.Single(data => data.LevelDifficultyType == _levelDifficulty);

    private void Awake()
    {
        _difficultyHandler.Init();
        UpdateDifficultyData(_levelDifficulty);
    }

    public void UpdateDifficultyData(LevelDifficultyType levelDifficulty)
    {
        _levelDifficulty = levelDifficulty;
        UpdateLetterType();
    }

    private void UpdateLetterType()
    {
        var letterTypeValues = Enum.GetValues(typeof(LetterType));
        var letterTypeValuesArray = new LetterType[letterTypeValues.Length];
        letterTypeValues.CopyTo(letterTypeValuesArray, 0);
        LetterType letterType = letterTypeValuesArray[UnityEngine.Random.Range(0, letterTypeValues.Length)];
        _letterType = letterType;
    }
}
