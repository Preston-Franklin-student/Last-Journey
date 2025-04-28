using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LastJourney
{
    public class Projectile : MonoBehaviour
    {
        public GameObject target;
        public Rigidbody2D rigidbody;
        public Timer timer;
        public int speed;

        public void Init(GameObject target)
        {
            StartCoroutine(Destroy());
            this.target = target;
            Vector2 directionVector = (target.transform.position - transform.position).normalized;
            rigidbody.velocity = directionVector * speed;
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Ground") Destroy(gameObject);
            if (other.gameObject.tag == "Player")
            {
                
            }
        }
        //For future use:
        //
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.001f);
    }
}
