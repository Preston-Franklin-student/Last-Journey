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
        public int decreaseTime;

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
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
        }
        //For future use:
        //
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.001f);
    }
}
