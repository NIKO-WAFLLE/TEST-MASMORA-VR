using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] Walls;
    public GameObject[] Doors;


    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            Doors[i].SetActive(status[i]);

            Walls[i].SetActive(!status[i]);
        }
    }
}
