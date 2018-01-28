using UnityEngine;

namespace Project
{

    public interface IMoveable
    {
        float MovingSpeed();

        void MoveTo(Vector3 destination);

        void MoveTo(GameObject destination);

    }

}
