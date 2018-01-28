using UnityEngine;

namespace Project
{

    /// <summary>
    /// Select and Deselect objects with a mouse click.
    /// </summary>
    public interface IMineable
    {
        float MiningSpeed();

        float MaxRessourceCapacity();

        float CurrentRessourceAmount();

        void Mine();

    }

}