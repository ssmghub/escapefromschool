using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Waypoint waypoint;
    public GameObject target;

    public GameObject bullet;
    public Transform shotTransform;
    public float fireRate = 1.17f;
    private float nextFire = 0.0F;

    public StateMachine stateMachine = new StateMachine(); // brain of the Enemy
    
    void Start ()
    {
        stateMachine.ChangeState(new State_Patrol(this));
    }

    float sightFov = 200.0f;

    void Update()
    {
        stateMachine.Update();
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
            // angle between us and the player
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            // reset whether we’ve seen the player
            seenTarget = false;
            RaycastHit hit;

            // is it less than our field of view
            if (angle < sightFov * 0.5f)
            {
                if (Physics.Raycast(transform.position + transform.up,
                direction.normalized,
                out hit,
                GetComponent<SphereCollider>().radius)) //how far it works
                {
                    if (hit.collider.gameObject == target)
                    {
                        // flag that we've seen the player
                        // remember their position
                        seenTarget = true;
                        lastSeenPosition = target.transform.position;
                    }
                }
            }
        }
    }
}
