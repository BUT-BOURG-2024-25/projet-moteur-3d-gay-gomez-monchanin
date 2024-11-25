using System.Collections;
using UnityEngine;

namespace Enemies {

    public class PlayerIsInRange : MonoBehaviour {

        private GameObject player;
        private BaseEnemy enemyStats;
        
        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
            enemyStats = GetComponent<BaseEnemy>();
            
            StartCoroutine(AttackPlayer());
        }

        private IEnumerator AttackPlayer() {
            while (gameObject.activeSelf) {
                if (player && Vector3.Distance(transform.position, player.transform.position) <= enemyStats.attackRange) {
                    enemyStats.AttackPlayer();
                }

                yield return new WaitForSeconds(1f / enemyStats.attackSpeed);
            }
        }
        
    }
    
}