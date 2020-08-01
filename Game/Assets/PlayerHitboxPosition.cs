using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxPosition : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
