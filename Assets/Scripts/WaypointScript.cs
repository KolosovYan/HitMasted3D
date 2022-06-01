using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public List<RagdollControl> enemysOnPoint;
    public bool CheckWaypointStatus()
    {
        if (enemysOnPoint.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
