using UnityEngine;

namespace Enemies {
    
    public class BaseEnemy : MonoBehaviour {
        
        [Header("Enemy Settings")]
        [SerializeField] public float health;
        [SerializeField] public float resistance;
        [SerializeField] public float damage;
        [SerializeField] public float attackSpeed;
        [SerializeField] public float attackRange;
        [SerializeField] public float speed;
        
        [Header("References")]
        [SerializeField] public Rigidbody rb;
        
        private GameObject player;
        
        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update() {
            if (!player || Vector3.Distance(transform.position, player.transform.position) <= attackRange) return;
            
            var playerDirection = (player.transform.position - transform.position).normalized;
            
            var newVelocity = playerDirection * speed;
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity;
        
            var lookDirection = player.transform.position;
            lookDirection.y = transform.position.y;
            
            transform.LookAt(lookDirection, Vector3.up);
        }

        public void AttackPlayer() {
            print("Attacking player: " + player.name);
        }

    }
    
}