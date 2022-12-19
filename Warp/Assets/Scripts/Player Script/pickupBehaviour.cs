using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBehaviour : MonoBehaviour
{

    [SerializeField] private LayerMask PickupObjectMask;
    [SerializeField] private Camera Player;
    [SerializeField] private Transform PickTarget;
    [SerializeField] private float range;
    private Rigidbody pickupObject;


    void start()
    {

    }

    void update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pickupObject.useGravity = true;
            pickupObject = null;
            return;
        }

        Ray CameraRay = Player.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, range, PickupObjectMask))
        {
            pickupObject = HitInfo.rigidbody;
            pickupObject.useGravity = false;


        }
    }

    void fixedUpdate()
    {
        if (pickupObject)
        {
            Vector3 directiontoPoint = PickTarget.position - pickupObject.position;
            float distancetoPoint = directiontoPoint.magnitude;

            pickupObject.velocity = directiontoPoint * 12f * distancetoPoint;
        }
    }
    

}
