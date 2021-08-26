using UnityEngine;
using TMPro;
using DG.Tweening;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _taskText;

    private void Start()
    {
        _taskText.DOFade(1, 1);
    }

    public void UpdateTaskText(string letter)
    {
        _taskText.text = "Find " + letter;
    }
}
