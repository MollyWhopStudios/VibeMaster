using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_DamageCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<TD_LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
