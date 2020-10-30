// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2019-present, Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Developer Agreement, located
// here: https://auth.magicleap.com/terms/developer
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;

namespace MagicLeap
{
    /// <summary>
    /// This example demonstrates using the magic leap raycast functionality to calculate intersection with the physical space.
    /// It demonstrates casting rays from the users headpose, controller, and eyes position and orientation.
    ///
    /// This example uses a raycast visualizer which represents these intersections with the physical space.
    /// </summary>
    public class RaycastExampleModified : MonoBehaviour
    {
        public enum RaycastMode
        {
            Left_IndexFinger,
            Right_IndexFinger
        }

        [SerializeField, Tooltip("The overview status text for the UI interface.")]
        private Text _overviewStatusText = null;

        [SerializeField, Tooltip("Raycast Visualizer.")]
        private MLRaycastVisualizer _raycastVisualizer = null;

        [SerializeField, Tooltip("Raycast from Left_IndexFinger.")]
        private MLRaycastBehavior _raycastLeft_IndexFinger = null;

        [SerializeField, Tooltip("Raycast from headpose.")]
        private MLRaycastBehavior _raycastRight_IndexFinger = null;
        

        [Space, SerializeField, Tooltip("MLControllerConnectionHandlerBehavior reference.")]
        private MLControllerConnectionHandlerBehavior _controllerConnectionHandler = null;

        private RaycastMode _raycastMode = RaycastMode.Left_IndexFinger;
        private int _modeCount = System.Enum.GetNames(typeof(RaycastMode)).Length;

        private float _confidence = 0.0f;

        /// <summary>
        /// Validate all required components and sets event handlers.
        /// </summary>
        void Awake()
        {

            if (_overviewStatusText == null)
            {
                Debug.LogError("Error: RaycastExampleModified._overviewStatusText is not set, disabling script.");
                enabled = false;
                return;
            }

            if (_raycastLeft_IndexFinger == null)
            {
                Debug.LogError("Error: RaycastExampleModified._raycastLeft_IndexFinger is not set, disabling script.");
                enabled = false;
                return;
            }

            if (_raycastRight_IndexFinger == null)
            {
                Debug.LogError("Error: RaycastExampleModified.Right_IndexFinger is not set, disabling script.");
                enabled = false;
                return;
            }

            if (_controllerConnectionHandler == null)
            {
                Debug.LogError("Error: RaycastExampleModified._controllerConnectionHandler not set, disabling script.");
                enabled = false;
                return;
            }

            _raycastLeft_IndexFinger.gameObject.SetActive(false);
            _raycastRight_IndexFinger.gameObject.SetActive(false);
            _raycastMode = RaycastMode.Left_IndexFinger;

            UpdateRaycastMode();

            #if PLATFORM_LUMIN
            MLInput.OnControllerButtonDown += OnButtonDown;
            #endif
        }

        void Update()
        {
            UpdateStatusText();
        }

        /// <summary>
        /// Cleans up the component.
        /// </summary>
        void OnDestroy()
        {
            #if PLATFORM_LUMIN
            MLInput.OnControllerButtonDown -= OnButtonDown;
            #endif
        }

        /// <summary>
        /// Updates type of raycast and enables correct cursor.
        /// </summary>
        private void UpdateRaycastMode()
        {
            DisableRaycast(_raycastVisualizer.raycast);

            switch (_raycastMode)
            {
                case RaycastMode.Left_IndexFinger:
                {
                    EnableRaycast(_raycastLeft_IndexFinger);
                    break;
                }

                case RaycastMode.Right_IndexFinger:
                {
                    EnableRaycast(_raycastRight_IndexFinger);
                    break;
                }
            }
        }

        /// <summary>
        /// Enables raycast behavior and raycast visualizer
        /// </summary>
        private void EnableRaycast(MLRaycastBehavior raycast)
        {
            raycast.gameObject.SetActive(true);
            _raycastVisualizer.raycast = raycast;

            #if PLATFORM_LUMIN
            _raycastVisualizer.raycast.OnRaycastResult += _raycastVisualizer.OnRaycastHit;
            _raycastVisualizer.raycast.OnRaycastResult += OnRaycastHit;
            #endif
        }

        /// <summary>
        /// Disables raycast behavior and raycast visualizer
        /// </summary>
        private void DisableRaycast(MLRaycastBehavior raycast)
        {
            if(raycast != null)
            {
                raycast.gameObject.SetActive(false);

                #if PLATFORM_LUMIN
                raycast.OnRaycastResult -= _raycastVisualizer.OnRaycastHit;
                raycast.OnRaycastResult -= OnRaycastHit;
                #endif
            }
        }

        /// <summary>
        /// Updates Status Label with latest data.
        /// </summary>
        private void UpdateStatusText()
        {
            _overviewStatusText.text = string.Format("<color=#dbfb76><b>{0} {1}</b></color>\n{2}: {3}\n\n",
                LocalizeManager.GetString("Controller"),
                LocalizeManager.GetString("Data"),
                LocalizeManager.GetString("Status"),
                LocalizeManager.GetString(ControllerStatus.Text));

            _overviewStatusText.text += string.Format("<color=#dbfb76><b>{0} {1}</b></color>\n{2}: {3} \n{4}: {5}\n\n",
                LocalizeManager.GetString("Raycast"),
                LocalizeManager.GetString("Data"),
                LocalizeManager.GetString("Mode"),
                LocalizeManager.GetString(_raycastMode.ToString()),
                LocalizeManager.GetString("Confidence"),
                LocalizeManager.GetString(_confidence.ToString()));

        }

        /// <summary>
        /// Handles the event for button down and cycles the raycast mode.
        /// </summary>
        /// <param name="controllerId">The id of the controller.</param>
        /// <param name="button">The button that is being pressed.</param>
        private void OnButtonDown(byte controllerId, MLInput.Controller.Button button)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId) && button == MLInput.Controller.Button.Bumper)
            {
                _raycastMode = (RaycastMode)((int)(_raycastMode + 1) % _modeCount);
                UpdateRaycastMode();
            }
        }

        /// <summary>
        /// Callback handler called when raycast has a result.
        /// Updates the confidence value to the new confidence value.
        /// </summary>
        /// <param name="state"> The state of the raycast result.</param>
        /// <param name="mode">The mode that the raycast was in (physical, virtual, or combination).</param>
        /// <param name="ray">A ray that contains the used direction and origin for this raycast.</param>
        /// <param name="result">The hit results (point, normal, distance).</param>
        /// <param name="confidence">Confidence value of hit. 0 no hit, 1 sure hit.</param>
        public void OnRaycastHit(MLRaycast.ResultState state, MLRaycastBehavior.Mode mode, Ray ray, RaycastHit result, float confidence)
        {
            _confidence = confidence;
        }
    }
}
