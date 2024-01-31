using System;
using System.Collections;
using System.Collections.Generic;
using Core.Configs;
using UnityEngine;

namespace Core.State
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Instance;
        private Timer activeTimer = null;
        public Timer ActiveTimer => activeTimer;

        public int ammo;
        public float maxTime = 4f;
        public List<Enemy> enemyes = new List<Enemy>();
        public int currentLevel = 1;
        public int curWave = 1;

        [SerializeField] private EnemyConfig enemyConfig = null;
        public static Action FinishedLevel;
        public static Action StartWaveAction;
        public static Action LevelUp;
        public static Action Startlevel;

        public class State 
        {
            public int curLevel = 1;
            public int curEnemies;
            public int curAmmo;
        }

        private State state = new State();

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

        public void LoseLevel()
        {
            FinishedLevel?.Invoke();
            RemoveTimer();
            GameObject.FindObjectOfType<WInWindow>(true).Show();
        }

        private void RemoveTimer()
        {
            var timeControoller = GameObject.FindObjectOfType<TimeController>();
            timeControoller.RemoveTimer(activeTimer);
        }

        public void TryKillEnemy()
        {
            state.curEnemies--;
            CheckProgress();
        }

        public void CheckProgress()
        {
            if (state.curEnemies <= 0)
            {
                if (curWave >= enemyConfig.MAX_WAVES)
                {
                    state.curLevel++;
                    currentLevel = state.curLevel;
                    LevelUp?.Invoke();
                    StartLevel();
                    curWave = 1;
                }
                else
                {
                    //StartWave();
                    StartLevel();
                    curWave++;
                }
            }
        }

        private void StartWave()
        {
            RemoveTimer();
            var timeControoller = GameObject.FindObjectOfType<TimeController>();
            activeTimer = timeControoller.StartTimer(maxTime, OnTimerOver, null);

            SpawnEnemies();
            GiveBullets();
            maxTime += 0.5f;

            StartWaveAction?.Invoke();
        }

        public void OnTimerOver()
        {
            LoseLevel();
        }

        public void StartLevel()
        {
            Startlevel?.Invoke();
            state.curEnemies = enemyConfig.enemiesOnLevel + state.curLevel;
            StartWave();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < state.curEnemies; i++)
            {
                enemyes.Add(GameObject.Instantiate(enemyConfig.enemy, new Vector3(0, 0, 0), Quaternion.identity));
            }
        }

        private void GiveBullets()
        {
            state.curAmmo = state.curEnemies + enemyConfig.additionalBullets;
            ammo = state.curAmmo;
        }
    }
}
