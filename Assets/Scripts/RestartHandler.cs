using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class RestartHandler : MonoBehaviour
{
    [SerializeField] private Image _panel;    
    [SerializeField] private GameObject _restartButton;

    [SerializeField] private LevelProperties _levelProperties;
    [SerializeField] private ContentRandomizer _contentRandomizer;
    [SerializeField] private CellFactory _cellFactory;
    [SerializeField] private LevelDifficultyHandler _difficultyHandler;

    public void ClearPanel()
    {
        StartCoroutine(OnPanelFadeOut());
        _restartButton.SetActive(false);
        _panel.DOFade(0, 1);
    }

    public void SpawnPanel()
    {
        StartCoroutine(OnPanelFadeIn());
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 1);
    }

    private IEnumerator OnPanelFadeIn()
    {
        yield return new WaitForSeconds(1);
        _restartButton.SetActive(true);
        _cellFactory.ClearGrid();
        _contentRandomizer.FillRemainingLists();
        _levelProperties.UpdateDifficultyData(_levelProperties.CurrentDifficulty.NextLevelDifficultyType);
        _difficultyHandler.Init();
    }

    private IEnumerator OnPanelFadeOut()
    {
        yield return new WaitForSeconds(1);
        _panel.gameObject.SetActive(false);
    }
}
