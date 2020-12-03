using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideRandom : MonoBehaviour
{
    public float InstanceRate = 1;
    public GameObject AsteroidePrefab;

    public float AsteroidePrefabLife;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        		Destroy(gameObject, 5);

        while (true)
        {
            Instantiate(AsteroidePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(InstanceRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
