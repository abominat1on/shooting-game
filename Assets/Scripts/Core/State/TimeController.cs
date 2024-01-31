using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.State
{
    public class TimeController : MonoBehaviour
    {
        public static TimeController Instance;
        private DateTime lastDateTime = default;
        private const float UNIT_TIME_SEC = 0.05f;
        private List<Timer> gamePlayTimers = new List<Timer>();

        public static Action<TimeSpan> TimeTickSec;

        public void StopAllTimers()
        {
            gamePlayTimers.Clear();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        public void Start()
        {
            lastDateTime = DateTime.Now;
        }

        public void Update()
        {
            var diff = DateTime.Now - lastDateTime;
            if (diff.TotalSeconds > UNIT_TIME_SEC)
            {
                lastDateTime = DateTime.Now;
                CheckTimers(diff);
                TimeTickSec?.Invoke(diff);
            }
        }

        private void CheckTimers(TimeSpan diff)
        {

            TickArray(gamePlayTimers, Time.timeScale);

            void TickArray(List<Timer> timers, float timeScale)
            {
                for (int i = 0; i < timers.Count; i++)
                {
                    float tickTime = (float)diff.TotalMilliseconds;
                    diff = TimeSpan.FromMilliseconds(tickTime * timeScale);
                    Timer timer = timers[i];
                    if (timer.AddSpanAndCheckStatus(diff))
                    {
                        timers.Remove(timer);
                    }
                }
            }
        }

        internal void RemoveTimer(Timer timer)
        {
            gamePlayTimers.Remove(timer);
        }

        public Timer StartTimer(float spanSec, Action TimerOver, Action<float> TimeTick, bool isSystemTimer = false)
        {
            lastDateTime = DateTime.Now;
            var newTimer = new Timer(spanSec, TimerOver, TimeTick);
            gamePlayTimers.Add(newTimer);

            return newTimer;
        }
    }

    public class Timer
    {
        private TimeSpan curSpan = default;
        private TimeSpan span = default;
        public Action TimerOver = null;
        public Action<float> TimeTick = null;

        public bool AddSpanAndCheckStatus(TimeSpan span)
        {
            curSpan = curSpan.Add(span);
            float timeLeft = (float)(this.span - curSpan).TotalSeconds;
            TimeTick?.Invoke(timeLeft);
            if (curSpan >= this.span)
            {
                TimerOver?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Timer(float sec, Action timerOver, Action<float> timeTick)
        {
            this.span = TimeSpan.FromSeconds(sec);
            TimerOver = timerOver;
            TimeTick = timeTick;
        }
    }
}