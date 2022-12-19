using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportMechanic : MonoBehaviour
{

    
    private RaycastHit lastRaycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private GameObject GetLookedAtObject()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float distance = 1000;

        if(Physics.Raycast (currentPosition,direction,out lastRaycastHit, distance))
            return lastRaycastHit.collider.gameObject;

        
        else
            return null;
        


    }

    private void telportToPosition()
    {
        transform.position = lastRaycastHit.point + lastRaycastHit.normal * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            if (GetLookedAtObject() != null)
                telportToPosition();
            
    }
}
