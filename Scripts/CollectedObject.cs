using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObject : MonoBehaviour
{
    PlayerManager playerManager;
    Transform sphere;
    
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        sphere = transform.GetChild(0);
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            Rigidbody rgbd = GetComponent<Rigidbody>();
            rgbd.useGravity = false;
            rgbd.constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Renderer>().material = playerManager.playerMaterial;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("CollectibleObject"))
        {
            if (!playerManager.collidedList.Contains(col.gameObject))
            {
                col.gameObject.tag = "CollectedObject";
                col.transform.parent = playerManager.CollectedPool;
                playerManager.collidedList.Add(col.gameObject);
                col.gameObject.AddComponent<CollectedObject>(); 
            }
        }
        if (col.gameObject.CompareTag("Obstacle"))
        {
            playerManager.collidedList.Remove(gameObject);
            Destroy(gameObject);
            Transform partcile = Instantiate(playerManager.particlePrefab, transform.position, Quaternion.identity);
            partcile.GetComponent<ParticleSystem>().startColor = playerManager.playerMaterial.color;
        }
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinnishLine"))
        {
            if (playerManager.levelState != PlayerManager.LevelState.Finished)
            {
                playerManager.levelState = PlayerManager.LevelState.Finished;
                playerManager.CallMakeSphere();
            }
        }
    }
    public void MakeSphere()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        sphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
        sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
        sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        sphere.gameObject.GetComponent<Renderer>().material = playerManager.playerMaterial;
    }
    public void DropObject()
    {
        sphere.gameObject.layer = 3;
        sphere.gameObject.GetComponent<SphereCollider>().isTrigger = false;
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.gameObject.GetComponent<Rigidbody>().useGravity = true;

    }
}
