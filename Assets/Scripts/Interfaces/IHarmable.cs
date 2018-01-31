using UnityEngine;

/// <summary>
/// Each class which can be attacked by enemys implements IFightable.
/// </summary>
namespace Project
{

    public interface IHarmable
    {

        float Health();

        void TakeDamage(float damage, Vector3 hitpoint);

        void Die();

    }

}
