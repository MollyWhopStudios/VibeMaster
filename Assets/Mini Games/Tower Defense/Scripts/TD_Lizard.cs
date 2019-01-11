using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Lizard : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<TD_Defender>())
        {
            GetComponent<TD_Attacker>().Attack(otherObject);
        }
    }

}
