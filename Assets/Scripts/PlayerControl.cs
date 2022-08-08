using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public List<Transform> Points;
    [SerializeField] private SceneController sceneController;
    private NavMeshAgent agent;
    private Animator anim;
    public int i = 0;

    private void Start()
    {
        transform.position = Points[0].position;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.velocity.magnitude > 1)
        {
            anim.Play("Run");
        }

        else
        {
            anim.Play("IDLE");
        }
    }

    public void MovePlayer()
    {
        i += 1;
        agent.SetDestination(Points[i].position);
    }

    public void CheckMove()
    {
        if (Points[i].GetComponent<WaypointScript>().CheckWaypointStatus())
        {
            if ((Points.Count - 1) != i)
            {
                MovePlayer();
            }
            else if ((Points.Count - 1) == i)
            {
                sceneController.RestartScene();
            }

        }
        else
        {
              Debug.Log("Enemy is Alive");
        }
    }
}
