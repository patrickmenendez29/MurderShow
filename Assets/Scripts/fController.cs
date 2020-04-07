using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fController : MonoBehaviour
{
    public GameObject player;
    public GameObject f1;
    public GameObject f2;
    public float xPos;
    public float startPos;
    public float endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (f1.transform.position.x <= endPos)
        {
            f1.transform.position = new Vector3(startPos,-5,0);
        }

        if (f2.transform.position.x <= endPos)
        {
            f2.transform.position = new Vector3(startPos, -5, 0);
        }
    }
}
