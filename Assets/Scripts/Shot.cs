using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    public GameObject prefab;
    public Bullet go;
    private BulletPool<Bullet> pool;
    private PlayerControl playerControl;
    private bool IsStarted = false;

    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        cam = Camera.main;
        pool = GetComponent<TestPool>().Pool;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsStarted)
            {
                IsStarted = true;
                playerControl.MovePlayer();
            }
            else
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);
                CreateBullet();
            }
        }
    }

    private void CreateBullet()
    {
        Debug.Log(pool);
        go = this.pool.GetFreeElement();
        go.transform.position = ray.GetPoint(3f);
        go.transform.forward = (Vector3)ray.direction;

    }
}
