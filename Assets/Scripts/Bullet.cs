using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletFlyDistance = 10;
    [SerializeField] private float speed;
    private PlayerControl playerControl;
    private RagdollControl ragd;

    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, Camera.main.transform.position) > BulletFlyDistance)
            gameObject.SetActive(false);

        if (gameObject.activeSelf)
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.root.gameObject);
        ragd = other.transform.root.gameObject.GetComponent<RagdollControl>();
        if (ragd != null)
        {
            ragd.MakePhysical(false);
            gameObject.SetActive(false);
            playerControl.Points[playerControl.i].GetComponent<WaypointScript>().enemysOnPoint.Remove(ragd);
            playerControl.CheckMove();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
