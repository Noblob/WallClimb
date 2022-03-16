using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbScript : MonoBehaviour
{
    public float open = 100f;
    public float range = 1f;
    public bool TouchingWall = false;
    public float UpwardSpeed = 3.3f;
    public Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
        if(Input.GetKey("w") & TouchingWall == true)     
        {
            transform.position += Vector3.up * Time.deltaTime * UpwardSpeed;
            GetComponent<Rigidbody>().isKinematic = true;
            TouchingWall = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if(Input.GetKeyUp("w"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            TouchingWall = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                TouchingWall = true;
            }
        }
    }
}
