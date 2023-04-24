using System;
using UnityEngine;

public class TimerManager : Manager
{
    public event Action<float> OnTimerUpdate;
    public override void OnFixedUpdate()
    {
        OnTimerUpdate?.Invoke(Time.fixedDeltaTime);
    }
}
