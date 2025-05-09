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
        Timer timer;
        public int speed;
        public int decreaseTime;
        public int projectileType;
        public bool inGround = true;

        public void Init(GameObject target)
        {
            StartCoroutine(Destroy());
            this.target = target;
            if (projectileType == 1)
            {
                StartCoroutine(DestroyInGround());
                Vector2 directionVector = (target.transform.position - transform.position).normalized;
                rigidbody.velocity = directionVector * speed;
            }
        }

        public void Init()
        {
            StartCoroutine(Destroy());
            if (projectileType == 2)
            {
                print("working");
                rigidbody.velocity = new Vector2(0, speed);
            }
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }

        IEnumerator DestroyInGround()
        {
            yield return new WaitForSeconds(0.3f);
            if (inGround == true) Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
                Destroy(gameObject);
            }
            if (other.gameObject.tag == "Ground" && inGround == false) Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Ground")
            {
                inGround = false;
            }
        }
        //For future use:
        //
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.001f);
    }
}
