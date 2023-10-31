using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float _timer;

    private Coroutine _coroutine;
    private Action<string> _callback;

    public bool IsTimer0()
    {
        return _timer <= 0;
    }

    public void StopTimer()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
    }

    public void ResumeTimer()
    {
        StartCoroutine(nameof(C_StartTimer), _callback);
    }

    public Timer SetTime(float time)
    {
        _timer = time;
        return this;
    }

    public void StartTimer(Action<string> callback)
    {
        _coroutine = StartCoroutine(nameof(C_StartTimer), callback);
    }

    private IEnumerator C_StartTimer(Action<string> callbackRunning)
    {
        yield return 0;
        while (_timer > 0)
        {
            yield return new WaitForEndOfFrame();
            _timer -= Time.deltaTime;
            callbackRunning.Invoke(Mathf.Round(_timer).ToString("00"));
        }

        callbackRunning.Invoke("00");
        yield return 0;
    }
}
