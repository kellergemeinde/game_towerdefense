using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IInteractable, IFightable, IHarmable
{
    public enum Behaviour { NEUTRAL, AGGRESSIVE, DEFENSIVE };

    //private members
    private float life;
    private float damage;
    private float armor;
    /// <summary>
    /// Movement and mining speed.
    /// </summary>
    private float speed;
    /// <summary>
    /// Maximum amount of plus benis this entity can carry.
    /// </summary>
    private float maxCapacity;
    /// <summary>
    /// Current amount of plus benis in the storage of this entity.
    /// </summary>
    private float usedCapacity;
    private Behaviour behaviour;

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public float Damage()
    {
        return damage;
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }

    public float Life()
    {
        return life;
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

    public float Speed()
    {
        return speed;
    }

    public void MoveTo(Vector3 destination)
    {

    }

    public void MoveTo(GameObject destination)
    {

    }

    public void Mine(PlusResource plusResource)
    {

    }

    public void Patroule(List<Vector3> route)
    {

    }

    public void SetBehaviour(Behaviour newBehaviour)
    {
        behaviour = newBehaviour;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
}
