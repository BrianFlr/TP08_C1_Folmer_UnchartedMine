using System;
using UnityEngine;

public class PlayerThrowAttack : MonoBehaviour
{
    //public event Action onPlayerAttack;

    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerProjectilesDataSo projectilesData;

    [Header("Object Pool")]
    //[SerializeField] private DaggerObjectPool daggerPool;

    [Header("Throw Point")]
    [SerializeField] private Transform throwPoint;

    private Rigidbody2D rb;

    private float daggerThrowRate = 0f;
    private float daggerNextThrowTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        daggerThrowRate = projectilesData.daggerThrowRate;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)playerData.throwProjectile))
        {
            if (Time.time >= daggerNextThrowTime)
            {
               // ThrowDagger();
            }
        }
    }
/*
    // Función para spawnear la daga y luego impulsarla.
    private void ThrowDagger()
    {
        onPlayerAttack?.Invoke();

        daggerNextThrowTime = Time.time + daggerThrowRate;

        // Tomo un objeto de la pool
        GameObject daggerClone = daggerPool.GetObjectDagger();

        // Ubico el objeto en la posicion de lanzamiento
        daggerClone.transform.position = new Vector2(throwPoint.position.x, throwPoint.position.y);

        // Tomo la referencia del script dentro de ese gameObject y llamo a la función para impulsar la daga.
        DaggerProjectile daggerProjectileScript = daggerClone.GetComponent<DaggerProjectile>();
        daggerProjectileScript.ImpulseDagger(MathF.Sign(transform.right.x));
    }*/
}
