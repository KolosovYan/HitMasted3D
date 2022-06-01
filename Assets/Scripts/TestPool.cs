using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    [SerializeField] private int poolCount = 5;
    [SerializeField] private Bullet cubePrefab;

    public BulletPool<Bullet> Pool;

    private void Awake()
    {
        this.Pool = new BulletPool<Bullet>(cubePrefab, poolCount);
        this.Pool.autoExpand = true;
    }
}
