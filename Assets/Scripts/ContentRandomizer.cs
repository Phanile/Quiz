using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContentRandomizer : MonoBehaviour
{
    [SerializeField] private LevelProperties _levelProperties;

    [SerializeField] private LetterData[] _letterDatas;
    [SerializeField] private LetterData[] _numberDatas;

    private List<LetterData> _letterDatasRemaining;
    private List<LetterData> _numberDatasRemaining;

    private void Awake()
    {
        FillRemainingLists();
    }

    public void FillRemainingLists()
    {
        _letterDatasRemaining = _letterDatas.ToList();
        _numberDatasRemaining = _numberDatas.ToList();
    }

    public LetterData[] GetRandomLetters()
    {
        List<LetterData> letterDatas = new List<LetterData>();
        for (int i = 0; i < _levelProperties.GetLetterCount; i++)
        {
            if (_levelProperties.LetterType == LetterType.Letter)
            {
                var letter = _letterDatasRemaining[Random.Range(0, _letterDatasRemaining.Count)];
                letterDatas.Add(letter);
                _letterDatasRemaining.Remove(letter);
            }
            if (_levelProperties.LetterType == LetterType.Number)
            {
                var number = _numberDatasRemaining[Random.Range(0, _numberDatasRemaining.Count)];
                letterDatas.Add(number);
                _numberDatasRemaining.Remove(number);
            }
        }
        return letterDatas.ToArray();
    }

    public LetterData ChooseRandomLetter(LetterData[] letterDatas)
    {
        return letterDatas[Random.Range(0, letterDatas.Length)];
    }
}
