using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Attacker : MonoBehaviour {

    [Range (0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<TD_LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        TD_LevelController levelController = FindObjectOfType<TD_LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
	}

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        TD_Health health = currentTarget.GetComponent<TD_Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

}
