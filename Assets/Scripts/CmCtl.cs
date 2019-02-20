using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmCtl : MonoBehaviour
{
    public Transform playerPosition;
    public Transform moveThreshold;

    // Update is called once per frame
    void Update()
    {

        if (playerPosition.position.x > moveThreshold.position.x)
        {
            transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        }
        
        else if(moveThreshold.position.x-playerPosition.position.x>8)
        {
            transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        }
        Debug.Log("pl:" + playerPosition.position.x + ";th:" + moveThreshold.position.x);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(moveThreshold.position, new Vector2(moveThreshold.position.x, moveThreshold.position.y + 10));
        Gizmos.DrawLine(moveThreshold.position, new Vector2(moveThreshold.position.x, moveThreshold.position.y - 10));
    }
}
