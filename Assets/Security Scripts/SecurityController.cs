using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityController : MonoBehaviour
{
    public Waypoint waypoint;
    public GameObject target;

    public GameObject bullet;
    public Transform shotTransform;
    public float fireRate = 1.0f;
    private float nextFire = 0.0F;

    public Sec_StateMachine sec_StateMachine = new Sec_StateMachine(); // brain of the Enemy

    void Start ()
    {
        sec_StateMachine.ChangeState(new Sec_State_Patrol(this));
    }


    float sightFov = 250.0f;


    void Update()
    {
        sec_StateMachine.Update();
    }

    public void fire()
    {
        Quaternion rotation = Quaternion.LookRotation(lastSeenPosition - shotTransform.position, Vector3.up);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(
                bullet,
                shotTransform.position,
                rotation);
        }
    }

    public bool seenTarget = false;
    public Vector3 lastSeenPosition;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == target)
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            seenTarget = false;
            RaycastHit hit;

            if (angle < sightFov * 0.5f)
            {
                if (Physics.Raycast(transform.position + transform.up,
                direction.normalized,
                out hit,
                GetComponent<SphereCollider>().radius *1.3f))
                {
                    if (hit.collider.gameObject == target)
                    {
                        seenTarget = true;
                        lastSeenPosition = target.transform.position;
                    }
                }
            }
        }
    }
}
