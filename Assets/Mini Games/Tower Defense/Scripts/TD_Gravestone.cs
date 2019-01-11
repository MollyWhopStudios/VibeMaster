using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Gravestone : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        TD_Attacker attacker = otherCollider.GetComponent<TD_Attacker>();

        if(attacker)
        {
            // TODO Add some sort of animation
        }

    }

}
