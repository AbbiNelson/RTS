using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    internal void ReceiveDamge(int damageToInflict)
    {
        health -= damageToInflict;
    }
}
