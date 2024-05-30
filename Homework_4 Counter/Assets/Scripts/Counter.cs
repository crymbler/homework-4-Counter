using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0.5f)] private float _delay;

    private bool IsClicked;
    private float _time;
    private WaitForSeconds _wait;

    public event Action<float> Changed;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _time = 0;
        IsClicked = false;
    }

    private void Update()
    {
        SwitchTimer();
    }

    private void SwitchTimer()
    {
        if (Input.GetMouseButtonUp(0) && IsClicked)
        {
            IsClicked = false;
            StopCoroutine(TimeCounter());

            return;
        }

        if (Input.GetMouseButtonUp(0) && IsClicked == false)
        {
            IsClicked = true;
            StartCoroutine(TimeCounter());

            return;
        }
    }

    private IEnumerator TimeCounter()
    {
        while (IsClicked)
        {
            _time++;

            Changed?.Invoke(_time);

            yield return _wait;
        }
    }
}