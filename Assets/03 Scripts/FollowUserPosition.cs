using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUserPosition : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3 (player.position.x, gameObject.transform.position.y, player.position.z);
    }
}
