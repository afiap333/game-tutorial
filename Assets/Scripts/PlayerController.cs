using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//followed: https://learn.unity.com/tutorial/set-up-a-2d-player-character?uv=2022.3&courseId=64774201edbc2a1638d25d18&projectId=64774230edbc2a143ab0e3a7#64d212d2edbc2a5cedc72221
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position=transform.position;
        position.x=position.x+0.1f;
        transform.position=position;
    }
}
