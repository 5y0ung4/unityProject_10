using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj_h : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (homeManager_h.hm.ms != homeManager_h.MorningState.Run)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "diary")
                {
                    print("diary");
                    StartCoroutine(homeManager_h.hm.findDiary());
                }
                else if (hitInfo.collider.gameObject.tag=="door_start")
                {
                    print("door");
                    StartCoroutine(homeManager_h.hm.openDoor());
                }
            }
        }
    }
}
