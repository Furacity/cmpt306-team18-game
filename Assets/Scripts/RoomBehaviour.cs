using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;

    public bool[] testStatus;

    public void UpdateRoom(bool[] status)
    {
        for(int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }

    public void UpdateRotation(bool[] direction)
    {
        if(tag == "endroom")
        {
            // only room with 1 opening is the end room, rotate it so it faces towards the direction given
            // default is right
            if (direction[0])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90, transform.rotation.z));
            }

            if (direction[1])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z));
            }

            if (direction[2])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }

            if (direction[3])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            }


            // we dont need an else because default entrance faces east
        }
        else if (tag == "hallway")
        {
            if (direction[0] && direction[1])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
            if (direction[2] && direction[3])
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z));
            }
        }
        else if (tag == "Lroom")
        {

        }
        else if (tag == "Troom")
        {

        }
        else if (tag == "4wayroom")
        {

        }
    }
}
