using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float speed;
    [SerializeField] float controllSpeed;

    //Touch Setting
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;
    void Start()
    {
        
    }

    
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controllSpeed * Time.fixedDeltaTime;
        }
        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
