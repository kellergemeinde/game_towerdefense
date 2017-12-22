using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IInteractable, IFightable, IHarmable
{
    //private members
    private float damage = 2f;
    private float speed = 2f;
    private float range = 20f;
    private float life = 100f;

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }

    public float Damage()
    {
        return damage;
    }

    public float Life()
    {
        return life;
    }

    public float Speed()
    {
        return speed;
    }

    public void Select()
    {
        throw new System.NotImplementedException();
    }

    public void Strike(IFightable enemy)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage, Vector3 hitpoint)
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
