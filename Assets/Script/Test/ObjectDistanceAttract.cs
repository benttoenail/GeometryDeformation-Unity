using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceAttract : MonoBehaviour {

    public GameObject obj;

    [SerializeField]
    GameObject attractor;

    [SerializeField]
    int count;

    private Vector3 attractPos;
    List<GameObject> refSphere = new List<GameObject>();

    float startTime;
    float smooth;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < count; i++)
        {

            GameObject temp = Instantiate(obj) as GameObject;
            refSphere.Add(temp);

        }

        startTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        float smooth = (Time.time - startTime) * .01f;

        Vector3[] currentPos = new Vector3[count];

        for(int i = 0; i < count; i++)
        {
            //Init positions
            attractPos = attractor.transform.position;
            Vector3 origin = transform.position;

            //Calculate positions of reference objects - Set position
            Vector3 destination = (attractPos + origin) / (i+1); //Get Center point of two Vectors
            currentPos[i] = refSphere[i].transform.position;

            //Set destination Vector
            Vector3 go = Vector3.Lerp(currentPos[i], destination, smooth / (i + 1));

            refSphere[i].transform.position = go;

        }
        	
	}
}
