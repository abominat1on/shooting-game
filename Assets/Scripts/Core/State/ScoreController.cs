using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.State
{
    public class ScoreController : MonoBehaviour
    {
        public static ScoreController Instance;
        [System.Serializable]
        public class State
        {
            public int MaxScore = 0;
        }

        private State state = new State();

        public int CurScore { private set; get; } = 0;

        public int MaxScore => state.MaxScore;

        public static Action<int> SetNewScore;

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

        internal bool TrySetScore(int newScore)
        {
            if (newScore > CurScore)
            {
                CurScore = newScore;
                SetNewScore?.Invoke(CurScore);
                if (state.MaxScore < newScore)
                {
                    state.MaxScore = newScore;
                }
                return true;
            }
            return false;
        }

        public void Rebuild()
        {
            CurScore = 0;
        }
    }
}

