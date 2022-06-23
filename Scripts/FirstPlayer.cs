using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    Rigidbody rgbd;
    bool isGrounded;
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = playerManager.playerMaterial;
        playerManager.collidedList.Add(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }
    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rgbd.useGravity = false;
        rgbd.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this);
    }
}
