using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2Int playerPos;
    void Start()
    {
        playerPos = new Vector2Int(0,0);
    }

    Vector3 SLerp(Vector3 a, Vector3 b, float t, float delta)
    {
        if(Mathf.Max(Mathf.Abs(b.x - a.x), Mathf.Abs(b.z - a.z)) > delta)
            return Vector3.Lerp(transform.position, new Vector3(playerPos.x, 0, playerPos.y), Time.deltaTime*12);
        else
            return b;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerPos += new Vector2Int(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")), Mathf.RoundToInt(Input.GetAxisRaw("Vertical")));
        }

        transform.position = SLerp(transform.position, new Vector3(playerPos.x, 0, playerPos.y), Time.deltaTime*5, 0.01f);
    }
}
