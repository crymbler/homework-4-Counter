using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Awake()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _counter.Changed += ChangeTime;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeTime;
    }

    private void ChangeTime(float time)
    {
        _text.text = time.ToString("");
    }
}