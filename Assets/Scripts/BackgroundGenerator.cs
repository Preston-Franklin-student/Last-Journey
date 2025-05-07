using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class BackgroundGenerator : MonoBehaviour
    {
        public GameObject[] backGroundObjects;
        public BackgroundGenerator generator;

        int selectedBackgroundObject;
        int nextTransformation;
        public int minTransformation;
        public int maxTransformation;
        public void GenerateBackground()
        {
            nextTransformation = 0;
            generator.transform.position = new Vector2(0, 0);

            selectedBackgroundObject = Random.Range(0, backGroundObjects.Length);
            Instantiate(backGroundObjects[selectedBackgroundObject], transform.position, transform.rotation);
            while (generator.transform.position.x < 200)
            {
                selectedBackgroundObject = Random.Range(0, backGroundObjects.Length);
                Instantiate(backGroundObjects[selectedBackgroundObject], transform.position, transform.rotation);
                nextTransformation += Random.Range(minTransformation, maxTransformation + 1);
                generator.transform.position = new Vector2(nextTransformation, 0);
            }
            selectedBackgroundObject = Random.Range(0, backGroundObjects.Length);
            Instantiate(backGroundObjects[selectedBackgroundObject], transform.position, transform.rotation);
        }
    }

}
