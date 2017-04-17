using UnityEngine;

namespace movementEngine
{
    public class Timer
    {
        public float timerStartValue;
        public float timerCurrentValue;

        private bool timerOn = false;

        public void TimerOn()
        {
            timerOn = true;
            timerCurrentValue = timerStartValue;
        }

        /// <summary>
        /// Place this method in Update()
        /// </summary>
        public void TimerTracker()
        {
            if (timerOn)
            {
                if (timerCurrentValue >= 0)
                {
                    timerCurrentValue -= Time.deltaTime;
                }
                else
                    timerOn = false;
            }
        }

        public Timer(float startValue)
        {
            timerStartValue = startValue;
        }

        public float GetCurrentTimerValue()
        {
            return timerCurrentValue;
        }

        public void AddToCurrentTimer(float addValue)
        {
            timerCurrentValue = addValue;
        }

        public void AddToStartTimer(float addValue)
        {
            timerStartValue = addValue;
        }
    }
}