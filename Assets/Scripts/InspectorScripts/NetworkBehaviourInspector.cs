
using UnityEngine;
using UnityEditor;

namespace Project
{

    [CustomEditor(typeof(NetworkBehaviour), true)]
    public class NetworkBehaviourInspector : Editor
    {

        private NetworkBehaviour nb;
        private SyncMode syncMode;
        private bool showNetworkInspector;
        private bool showMovement = true;
        private bool showRotation = true;

        public override void OnInspectorGUI()
        {
            GUI.backgroundColor = Color.cyan;

            nb = target as NetworkBehaviour;
            syncMode = nb.syncMode;

            // Header
            showNetworkInspector = EditorGUILayout.Foldout(showNetworkInspector, "Network Replication");

            if (showNetworkInspector)
            {
                // Send Rate
                nb.SendRate = EditorGUILayout.IntSlider("Send Rate", nb.SendRate, 0, 60);

                nb.transformSyncMode = (ETransformSyncMode)EditorGUILayout.EnumPopup("Transform Sync Mode", nb.transformSyncMode);

                switch (nb.transformSyncMode)
                {
                    case ETransformSyncMode.SyncNone:
                        syncMode = new SyncMode();
                        break;
                    case ETransformSyncMode.SyncTransform:
                        SyncTransform();
                        break;
                    case ETransformSyncMode.SyncRigidbody2D:
                        SyncRigidbody2D();
                        break;
                    case ETransformSyncMode.SyncRigidbody3D:
                        SyncRigidbody3D();
                        break;
                    case ETransformSyncMode.SyncCharacterController:
                        SyncCharacterController();
                        break;
                }
            }
        }

        private void SyncTransform()
        {
            syncMode = new SyncTransform();
            var s = syncMode as SyncTransform;

            showMovement = EditorGUILayout.Foldout(showMovement, "Movement");
            if (showMovement)
            {
                s.MovementThreshold = EditorGUILayout.FloatField("Movement Threshold", s.MovementThreshold);
                s.SnapThreshold = EditorGUILayout.FloatField("Snap Threshold", s.SnapThreshold);
                s.InterpolateMovement = EditorGUILayout.FloatField("Interpolate Movement", s.InterpolateMovement);
            }

            showRotation = EditorGUILayout.Foldout(showRotation, "Rotation");
            if (showRotation)
            {
                s.RotationAxis = (ERotationAxis)EditorGUILayout.EnumPopup("Rotation Axis", s.RotationAxis);
                s.InterpolateRotation = EditorGUILayout.FloatField("Interpolate Rotation", s.InterpolateRotation);
                s.CompressRotation = (ECompression)EditorGUILayout.EnumPopup("Compress Rotation", s.CompressRotation);
                s.SyncAngularVelocity = EditorGUILayout.Toggle("Sync Angular Velocity", s.SyncAngularVelocity);
            }
        }

        private void SyncRigidbody3D()
        {
            SyncTransform();

            if (nb.GetComponent<Rigidbody>())
            {
                ShowVelocityThreshold();
            }
            else
            {
                EditorGUILayout.HelpBox("Missing Rigidbody Component!", MessageType.Error);
            }
        }

        private void SyncRigidbody2D()
        {
            SyncTransform();

            if (nb.GetComponent<Rigidbody2D>())
            {
                ShowVelocityThreshold();
            }
            else
            {
                EditorGUILayout.HelpBox("Missing Rigidbody2D Component!", MessageType.Error);
            }
        }

        private void SyncCharacterController()
        {
            SyncTransform();

            if (!nb.GetComponent<CharacterController>())
            {
                EditorGUILayout.HelpBox("Missing CharacterController Component!", MessageType.Error);
            }
        }

        private void ShowVelocityThreshold()
        {
            if (showRotation)
            {
                syncMode = new SyncRigidbody();
                var s = syncMode as SyncRigidbody;
                s.VelocityThreshold = EditorGUILayout.FloatField("Velocity Threshold", s.VelocityThreshold);
            }
        }
    }
}
