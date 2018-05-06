
using UnityEngine;

namespace Project {

    public enum ETransformSyncMode { SyncNone, SyncTransform, SyncRigidbody2D, SyncRigidbody3D, SyncCharacterController }

    public enum ERotationAxis { None, X, Y, Z, XY, XZ, XYZ }

    public enum ECompression { None, Low, High }

    public class SyncMode { }

    public class SyncTransform : SyncMode
    {
        //Movement

        public float MovementThreshold = 0.001f;

        public float SnapThreshold = 5f;

        public float InterpolateMovement = 1f;

        //Rotation

        public ERotationAxis RotationAxis = ERotationAxis.XYZ;

        public float InterpolateRotation = 1f;

        public ECompression CompressRotation = ECompression.None;

        public bool SyncAngularVelocity = false;
    }

    public class SyncRigidbody : SyncTransform
    {
        //Movement

        public float VelocityThreshold = 0.0001f;
    }

    /// <summary>
    /// Every class which needs to be replicated, must inherit from this class.
    /// </summary>
    public class NetworkBehaviour : MonoBehaviour
    {

        public Vector3 ReplicatedLocation { get; private set; }
        public Vector3 ReplicatedRotation { get; private set; }

        public int SendRate = 15;

        public ETransformSyncMode transformSyncMode = ETransformSyncMode.SyncTransform;

        public SyncMode syncMode;
    }

}
