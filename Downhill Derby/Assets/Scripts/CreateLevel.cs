using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    public GameObject LevelPrefab;
    public GameObject OldLevel = null;
    public GameObject Player;
    Queue<GameObject> pool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (LevelPrefab)
        {
            pool.Enqueue(LevelPrefab);
        }
        for (int i = 0; i <5; i++)
        {
            LevelPrefab = Instantiate(LevelPrefab, (LevelPrefab.transform.position + new Vector3(0, -16.38f, 45.01f)), LevelPrefab.transform.rotation);
            pool.Enqueue(LevelPrefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        OldLevel = pool.Dequeue();
        if (Player.transform.position.y < OldLevel.transform.position.y - 100 && Player.transform.position.z > OldLevel.transform.position.z + 100)
        {
            OldLevel.transform.position = LevelPrefab.transform.position + new Vector3(0, -16.38f, 45.01f);
            LevelPrefab = OldLevel;
        }
        pool.Enqueue(OldLevel);
    }
}
