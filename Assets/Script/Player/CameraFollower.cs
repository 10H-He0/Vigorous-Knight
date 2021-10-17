using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(PlayerControl.x, PlayerControl.y, -10);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
