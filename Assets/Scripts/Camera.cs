using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float smooth = 0.15f;
    public GameObject target;

	void LateUpdate ()
    {
        if (target)
        {
            Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, pos, smooth);
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
