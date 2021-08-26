using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty Level")]
public class DifficultyLevelData : ScriptableObject
{
    [SerializeField] private int _cellCount;
    [SerializeField] private LevelDifficultyType _difficultyType;
    [SerializeField] private LevelDifficultyType _nextLevelDifficultyType;

    public int CellCount => _cellCount;
    public LevelDifficultyType LevelDifficultyType => _difficultyType;
    public LevelDifficultyType NextLevelDifficultyType => _nextLevelDifficultyType;
}
