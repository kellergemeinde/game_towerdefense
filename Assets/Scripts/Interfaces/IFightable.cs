using UnityEngine;

/// <summary>
/// Each class which can be attacked by enemys implements IFightable.
/// </summary>
namespace Project {

    public interface IFightable {

        void TakeDamage(float damage, Vector3 hitpoint);

        void Death();

        float Life();

    }

}