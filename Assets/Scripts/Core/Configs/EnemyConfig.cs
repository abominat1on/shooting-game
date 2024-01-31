using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 1)]

    public class EnemyConfig : ScriptableObject
    {
        [SerializeField]public Enemy enemy;
        public int enemiesOnLevel;
        public int additionalBullets = 2;
        public int MAX_WAVES = 3;

    }


}