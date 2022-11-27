using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedChaser : MonoBehaviour
{
    [Tooltip("The target we try to chase.")]
    public GameObject target;

    [Tooltip("The distance at which we start chasing the target.")]
    [SerializeField] float agroDistance = 10f;

    [Tooltip("The distance at which we stop chasing the target.")]
    [SerializeField] float stoppingDistanceY = .1f;

    [Tooltip("The minimum distance we try to be from the target.")]
    [SerializeField] float minimumDistanceX = .05f;

    [Tooltip("The maximum distance we try to be from the target.")]
    [SerializeField] float maximumDistanceX = .05f;

    public double dist = 0;

    IMove motor;
    bool isAgro = false;
    float lastUpdate = 0f;

    void Start(){
        motor = GetComponent<IMove>();
        if (GameObject.FindObjectOfType<PlayerInputController>())
        {
            target = GameObject.FindObjectOfType<PlayerInputController>().gameObject;
        }
    }

    void FixedUpdate(){
        //Check to see if we should go aggresive
        if (!isAgro && (target.transform.position - transform.position).magnitude <= agroDistance) {
            isAgro = true;
        }

        //if we are aggresive, lets move towards our target
        dist = Mathf.Sqrt(new Vector2((target.transform.position.x - transform.position.x), 2*((target.transform.position.y) - (transform.position.y))).sqrMagnitude);
        if (isAgro && Time.time > lastUpdate + .1f) {
            lastUpdate = Time.time;
            if (target != null){
                Vector2 destination = new Vector2(transform.position.x, transform.position.y);
                if (Mathf.Abs(target.transform.position.y - transform.position.y) > stoppingDistanceY) {
                    destination.y = target.transform.position.y;
                }
                if (Mathf.Abs(target.transform.position.x - transform.position.x) < minimumDistanceX) {
                    //We are closer than we want, so lets back up to our minimum distance
                    float retreatVector = transform.position.x - target.transform.position.x;
                    float retreatDir = (retreatVector / Mathf.Abs(retreatVector)) * minimumDistanceX;
                    destination.x = target.transform.position.x + retreatDir;
                }
                if (Mathf.Abs(target.transform.position.x - transform.position.x) > maximumDistanceX) {
                    //We are further than we want, so lets move up to our maximum distance
                    float approachVector = target.transform.position.x - transform.position.x;
                    float approachDir = (approachVector / Mathf.Abs(approachVector)) * maximumDistanceX;
                    destination.x = target.transform.position.x + approachDir;
                }
                motor.Move(destination);
            }
            else {
                Debug.Log(gameObject.name + " is agro, but has no target assigned");
            }
        }
    }


}
