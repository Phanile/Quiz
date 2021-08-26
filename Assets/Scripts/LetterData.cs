using UnityEngine;

[CreateAssetMenu(menuName = "Letter")]
public class LetterData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _letter;
    [SerializeField] private LetterType _letterType;

    public Sprite Sprite => _sprite;
    public string Letter => _letter;
    public LetterType LetterType => _letterType;
}
