using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _letterImage;
    [SerializeField] private string _letter;

    public UnityAction<Cell> OnCellTaped { get; set; }

    public void Init(LetterData data)
    {
        _letterImage.sprite = data.Sprite;
        _letter = data.Letter;
    }

    public void OnPointerClick()
    {
        OnCellTaped?.Invoke(this);
    }
}
