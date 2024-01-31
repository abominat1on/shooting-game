using System.Collections;
using System.Collections.Generic;
using Core.State;
using UnityEngine;

namespace Core.Game
{
    [RequireComponent(typeof(Camera))]
    public class CameraRaycaster : MonoBehaviour
    {
        private Camera mainCamera = null;
        private int enemyKilledScore;
        private int enemyKilled;

        private void Awake()
        {
            mainCamera = GetComponent<Camera>();

            LevelController.FinishedLevel += OnEndLevel;
        }

        private void OnDestroy()
        {
            LevelController.FinishedLevel -= OnEndLevel;
        }

        private void OnEndLevel()
        {
            var ScoreController = GameObject.FindObjectOfType<ScoreController>();
            ScoreController.TrySetScore(enemyKilledScore);
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var levelController = GameObject.FindObjectOfType<LevelController>();
                RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                if (levelController.ammo > 0)
                {
                    levelController.ammo -= 1;
                    IPointerDownSpriteRenderer trigger = null;
                    if (hit)
                    {
                        trigger = hit.collider.GetComponent<IPointerDownSpriteRenderer>();
                        levelController.TryKillEnemy();
                        enemyKilledScore++;

                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        Debug.Log("промах");
                    }

                    if (trigger != null)
                    {
                        trigger.OnClick();
                    }
                }
                else
                {
                    levelController.LoseLevel();
                }
            }
        }
    }
}