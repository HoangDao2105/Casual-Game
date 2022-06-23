using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerState playerState;
    public LevelState levelState;
    public Material playerMaterial;
    public Transform particlePrefab;
    public List<GameObject> collidedList;
    public Transform CollectedPool;
    public enum PlayerState
    {
        Stopped,
        Move
    }
    public enum LevelState
    {
        NotFinished,
        Finished
    }
    public void CallMakeSphere()
    {
        foreach (GameObject obj in collidedList)
        {
            obj.GetComponent<CollectedObject>().MakeSphere();
        }
    }
}
