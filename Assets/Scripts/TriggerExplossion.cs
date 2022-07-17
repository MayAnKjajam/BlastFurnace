using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerExplossion : MonoBehaviour
{
    public GameObject[] ExplossionPrefab;
    public GameObject SmokePrefab1, SmokePrefab2, SmokePrefab3;
    public Rigidbody[] allRBs;
    public bool explode;
    public Transform[] BlastTransform;
  
    // Start is called before the first frame update
    void Start()
    {
        allRBs = GetComponentsInChildren<Rigidbody>();
        for (int r = 0; r < allRBs.Length; r++)
        {
            allRBs[r].isKinematic = true;
            allRBs[r].gameObject.AddComponent<MeshCollider>().convex = true;
            allRBs[r].mass = .1f;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            SmokePrefab1.SetActive(true);
            SmokePrefab2.SetActive(false);
            SmokePrefab3.SetActive(false);
            StartCoroutine(StartBlast(0));
            explode = false;
        }
    }

  

    IEnumerator StartBlast(int index)
    {
        
        GameObject Prefab = GameObject.Instantiate(ExplossionPrefab[Random.Range(0,ExplossionPrefab.Length-1)], BlastTransform[index]);
        index++;
        yield return new WaitForSeconds(.1f);
        if (index == 2)
        {
            for (int r = 0; r < allRBs.Length; r++)
            {
                allRBs[r].isKinematic = false;
            }
        }
        if (index == 4)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(StartBlast(index));
        }
    }
}
