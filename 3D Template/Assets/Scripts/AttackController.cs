using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;

    public Material idleStateMaterial;
    public Material followStateMaterial;
    public Material attackStateMaterial;
    public int unitDamage;

    public bool isPlayer;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer && other.CompareTag("Enemy") && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlayer && other.CompareTag("Enemy") && targetToAttack != null)
        {
            targetToAttack = null;
        }
    }

    public void SetIdleMaterial()
    {
        GetComponent<Renderer>().material = idleStateMaterial;
    }

    public void SetFollowMaterial()
    {
        GetComponent<Renderer>().material = followStateMaterial;
    }

    public void SetAttackMaterial()
    {
        GetComponent<Renderer>().material = attackStateMaterial;
    }

    private void OnDrawGizmos()
    {
        //Follow
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 10*0.5f);
        //Attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
        //Stop
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 2.2f);
    }
}
