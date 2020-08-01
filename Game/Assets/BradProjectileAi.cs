using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradProjectileAi : MonoBehaviour
{
    public float speed;
    public Transform bradFace;
    private Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(bradFace.position.x, bradFace.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {



            DestroyProjectile();



        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {

        Destroy(gameObject);

    }
}
