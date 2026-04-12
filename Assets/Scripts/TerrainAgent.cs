using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class TerrainAgent : Agent
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;

    private Rigidbody rb;
    private float startY;
    private Vector3 startPos; 

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.position; 
        startY = transform.position.y;
    }

    public override void OnEpisodeBegin()
    {
        
        transform.position = startPos;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rb.linearVelocity);

        float heightDiff = transform.position.y - startY;
        sensor.AddObservation(heightDiff);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            float slope = Vector3.Angle(hit.normal, Vector3.up);
            sensor.AddObservation(slope / 90f);
        }
        else
        {
            sensor.AddObservation(0f);
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float move = actions.ContinuousActions[0];
        float turn = actions.ContinuousActions[1];

        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
        rb.AddForce(transform.forward * move * moveSpeed);

        AddReward(0.001f);

        float heightDiff = transform.position.y - startY;
        if (heightDiff > 0.5f)
        {
            AddReward(-0.01f);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            float slope = Vector3.Angle(hit.normal, Vector3.up);

            if (slope > 20f)
            {
                AddReward(-0.02f);
            }
            else
            {
                AddReward(0.002f);
            }
        }

        if (transform.position.y > startY + 1.5f)
        {
            AddReward(-1f);

            // Push agent away from high area
            rb.AddForce(Vector3.down * 2f, ForceMode.Impulse);

            //EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.ContinuousActions;

        actions[0] = Input.GetAxis("Vertical");
        actions[1] = Input.GetAxis("Horizontal");
    }
}