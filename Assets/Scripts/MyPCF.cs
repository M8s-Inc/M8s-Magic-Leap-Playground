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

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;

namespace MagicLeap
{
    /// <summary>
    /// Demonstrates how to persist objects dynamically by interfacing with
    /// the MLPersistence.PersistentCoordinateFramesCoordinateFrames API and the BindingsLocalStorage class.
    /// </summary>
    public class MyPCF : MonoBehaviour
    {
        public DeviceManager deviceManager;
        public M8MLController myController; 

        [SerializeField, Tooltip("Persistent Content to create.")]
        private GameObject _content = null;

        [SerializeField, Tooltip("Controller to use.")]
        private MLControllerConnectionHandlerBehavior _controller = null;

        #pragma warning disable 414
        [SerializeField, Tooltip("Distance in front of Controller to create content.")]
        private float _distance = 0.2f;

        [SerializeField, Tooltip("PCFVisualizer behavior to use when debugging.")]
        private PCFVisualizer _pcfVisualizer = null;
        #pragma warning restore 414

        // Used to keep track of the content that was created or regained during a headpose session.
        // So.... I should create a dictionary of gameobjects to hold my devices?
        private Dictionary<PersistentDevice, string> _persistentContentMap = new Dictionary<PersistentDevice, string>();

        //public Dictionary<string, GameObject> deviceDictionary = new Dictionary<string, GameObject>();

        [SerializeField, Tooltip("Number of frames to perform delete all gesture before executing the deletion.")]
        private int _deleteAllSequenceMinFrames = 60;
        private int _deleteAllSequenceFrameCount = 0;
        private bool _deleteAllInitiated = false;

        [SerializeField, Tooltip("Status Text")]
        private Text _statusText = null;

        #if PLATFORM_LUMIN
        private bool bindingsLoaded = false;
        #endif

        public static int numPersistentContentCreated
        {
            get;
            set;
        }

        public static int numPersistentContentRegained
        {
            get;
            set;
        }

        public static int numTotalPCFs
        {
            get;
            set;
        }

        public static int numSingerUserSingleSessionPCFs
        {
            get;
            set;
        }

        public static int numSingleUserMultiSessionPCFs
        {
            get;
            set;
        }

        public static int numMultiUserMultiSessionPCFs
        {
            get;
            set;
        }

        /// <summary>
        /// Validates fields.
        /// </summary>
        void Awake()
        {
            //if (_content == null || _content.GetComponent<PersistentDevice>() == null)
            //{
            //    Debug.LogError("Error: PCFExample._content is not set or is missing PersistentDevice behavior, disabling script.");
            //    enabled = false;
            //    return;
            //}

            if (_controller == null)
            {
                Debug.LogError("Error: PCFExample._controller is not set, disabling script.");
                enabled = false;
                return;
            }

            if (_statusText == null)
            {
                Debug.LogError("Error: PCFExample._statusText is not set, disabling script.");
                enabled = false;
                return;
            }
        }

        /// <summary>
        /// Starts APIs, registers to MLInput events, and restores content.
        /// </summary>
        void Start()
        {
#if PLATFORM_LUMIN
            MLResult result = MLPersistentCoordinateFrames.Start();
            if (!result.IsOk)
            {
                Debug.LogErrorFormat("Error: PCFExample failed starting MLPersistentCoordinateFrames, disabling script. Reason: {0}", result);
                enabled = false;
                return;
            }

            PCFVisualizer.OnFindAllPCFs += HandleOnFindAllPCFs;
            MLPersistentCoordinateFrames.OnLocalized += HandleOnLocalized;

            MLInput.OnControllerButtonDown += HandleControllerButtonDown;
            MLInput.OnControllerTouchpadGestureStart += HandleTouchpadGestureStart;
            MLInput.OnControllerTouchpadGestureContinue += HandleTouchpadGestureContinue;
            MLInput.OnControllerTouchpadGestureEnd += HandleTouchpadGestureEnd;
#endif
        }

        /// <summary>
        /// Updates the status text inside the UI.
        /// </summary>
        void Update()
        {
            string exampleStatus = "";

            if (_deleteAllInitiated)
            {
                if (_deleteAllSequenceFrameCount < _deleteAllSequenceMinFrames)
                {
                    exampleStatus = string.Format("<color=yellow>{0} {1:P} {2}.</color>",
                        LocalizeManager.GetString("DeleteAllSequence"),
                        LocalizeManager.GetString("Complete"),
                        (float)(_deleteAllSequenceFrameCount) / _deleteAllSequenceMinFrames);
                }
            }

            _statusText.text = string.Format("<color=#dbfb76><b>{0}</b></color>\n{1}: {2}\n\n",
                LocalizeManager.GetString("ControllerData"),
                LocalizeManager.GetString("Status"),
                LocalizeManager.GetString(ControllerStatus.Text));

#if PLATFORM_LUMIN
            _statusText.text += string.Format("<color=#dbfb76><b>{0}</b></color>\n{1}: {2}\n{3}\n",
                LocalizeManager.GetString("ExampleData"),
                LocalizeManager.GetString("Status"),
                LocalizeManager.GetString(MLPersistentCoordinateFrames.IsLocalized ? "LocalizedToMap" : "NotLocalizedToMap"),
                LocalizeManager.GetString(exampleStatus));
#endif

            _statusText.text += string.Format("{0}: {1}\n", LocalizeManager.GetString("RegainedContent"), numPersistentContentRegained);

            _statusText.text += string.Format("{0}: {1}\n\n", LocalizeManager.GetString("CreatedContent"), numPersistentContentCreated);

            if (PCFVisualizer.IsVisualizing)
            {
                _statusText.text += string.Format("{0}: {1}\n", LocalizeManager.GetString("Total PCFCount"), numTotalPCFs);
                _statusText.text += string.Format("{0}: {1}\n", LocalizeManager.GetString("Singer-Single PCFCount"), numSingerUserSingleSessionPCFs);
                _statusText.text += string.Format("{0}: {1}\n", LocalizeManager.GetString("Single-Multi PCFCount"), numSingleUserMultiSessionPCFs);
                _statusText.text += string.Format("{0}: {1}\n", LocalizeManager.GetString("Multi-Multi PCFCount"), numMultiUserMultiSessionPCFs);
            }
        }

        /// <summary>
        /// Stops the MLPersistentCoordinateFrames API and unregisters from events and
        /// </summary>
        void OnDestroy()
        {
#if PLATFORM_LUMIN
            PCFVisualizer.OnFindAllPCFs -= HandleOnFindAllPCFs;
            MLPersistentCoordinateFrames.OnLocalized -= HandleOnLocalized;
            MLPersistentCoordinateFrames.Stop();
            MLHeadTracking.Stop();
            MLInput.OnControllerButtonDown -= HandleControllerButtonDown;
            MLInput.OnControllerTouchpadGestureStart -= HandleTouchpadGestureStart;
            MLInput.OnControllerTouchpadGestureContinue -= HandleTouchpadGestureContinue;
            MLInput.OnControllerTouchpadGestureEnd -= HandleTouchpadGestureEnd;
#endif
        }

        /// <summary>
        /// Handle for when localization is gained or lost.
        /// Attempts to read all the locally stored bindings when localized and resets the counters when localization is lost.
        /// </summary>
        /// <param name="localized"> Map Events that happened. </param>
        private void HandleOnLocalized(bool localized)
        {
#if PLATFORM_LUMIN
            if (localized)
            {
                if (bindingsLoaded)
                {
                    if (_persistentContentMap.Count > 0)
                    {
                        List<PersistentDevice> keys = new List<PersistentDevice>(_persistentContentMap.Keys);
                        foreach (PersistentDevice persistentContent in keys)
                        {
                            _persistentContentMap[persistentContent] = "Regained";
                            ++numPersistentContentRegained;
                        }
                    }
                }
                else
                {
                    RegainAllStoredBindings();
                }
            }
            else
            {
                numPersistentContentCreated = 0;
                numPersistentContentRegained = 0;
                numTotalPCFs = 0;
                numSingerUserSingleSessionPCFs = 0;
                numSingleUserMultiSessionPCFs = 0;
                numMultiUserMultiSessionPCFs = 0;
            }
#endif
        }

        /// <summary>
        /// Reads all stored persistent bindings.
        /// Each stored binding will contain a PCF object with a CFUID.
        /// Use that stored CFUID to see if the PCF exists in this session, if it does then the stored binding can be regained.
        /// If the binding is regained correctly then the persistent content will retain it's pose from the last known launch.
        /// </summary>
        private void RegainAllStoredBindings()
        {
            #if PLATFORM_LUMIN
            TransformBinding.storage.LoadFromFile();

            List<TransformBinding> allBindings = TransformBinding.storage.Bindings;

            List<TransformBinding> deleteBindings = new List<TransformBinding>();

            int devices = 0;
            //Testing to make sure this dictionary has shit.
            Debug.Log("Testing deviceDictionary inside MyPCF");
            foreach (var device in deviceManager.deviceDictionary)
            {
                devices++;
                Debug.Log("device name: " + device.Value.name + "  prefab type: " + device.Value.GetComponent<MagicLeap.PersistentDevice>().deviceData.prefabType + "  ID : " + device.Value.GetComponent<MagicLeap.PersistentDevice>().deviceData.id);
            }

            //Idk if this is where this should go but lets see. 
            //if (deviceManager.deviceDictionary != null)
            if (devices>0)
            {
                
            }

            foreach (TransformBinding storedBinding in allBindings)
            {
                // Try to find the PCF with the stored CFUID.
                MLResult result = MLPersistentCoordinateFrames.FindPCFByCFUID(storedBinding.PCF.CFUID, out MLPersistentCoordinateFrames.PCF pcf);

                if (pcf != null && MLResult.IsOK(pcf.CurrentResultCode))
                {
                    Debug.Log("Stored Binding ID: " + storedBinding.Id);
                    Debug.Log("Stored Binding prefab type: " + storedBinding.PrefabType);

                    //I need to find a way to decide the _content gameObject based on what object was paired to a specific PCF/CFUID
                    //Or maybe I can take storedBinding.PrefabType and spawn 

                    GameObject gameObj = null;

                    if (deviceManager.deviceDictionary.TryGetValue(storedBinding.Id, out gameObj))
                    {
                        Debug.Log("Inside RegainAllStoredBindings - deviceDictionary ID compare worked " + storedBinding.Id);

                        PersistentDevice persistentContent = gameObj.GetComponent<PersistentDevice>();

                        persistentContent.DeviceTransformBinding = storedBinding;
                        persistentContent.DeviceTransformBinding.Bind(pcf, gameObj.transform, true);

                        //do i need the contentTap?
                        //ContentTap contentTap = persistentContent.GetComponent<ContentTap>();
                        //contentTap.OnContentTap += OnContentDestroy;

                        ++numPersistentContentRegained;
                        _persistentContentMap.Add(persistentContent, "Regained");

                    }
                    else
                    {
                        Debug.Log("Inside RegainAllStoredBindings - deviceDictionary ID compare failed" + storedBinding.Id);
                        Debug.Log("deleting Binding");
                        deleteBindings.Add(storedBinding);

                    }

                }
                else
                {
                    deleteBindings.Add(storedBinding);
                }
            }

            foreach (TransformBinding storedBinding in deleteBindings)
            {
                storedBinding.UnBind();
            }

            bindingsLoaded = true;
            #endif
        }

        /// <summary>
        /// Instantiates a new object with MLPCFPersistentContent. The MLPCFPersistentContent is
        /// responsible for restoring and saving itself.
        /// </summary>
        /// <param name="position">Position to spawn the content at.</param>
        /// <param name="rotation">Rotation to spawn the content at.</param>
        public void CreateDevicePCF(GameObject gameObj)
        {
            
            //GameObject gameObj = Instantiate(prefab, myController.attachPoint.transform.position, myController.attachPoint.transform.rotation);
            
            #if PLATFORM_LUMIN
            MLPersistentCoordinateFrames.FindClosestPCF(myController.attachPoint.transform.position, out MLPersistentCoordinateFrames.PCF pcf);

            PersistentDevice persistentContent = gameObj.GetComponent<PersistentDevice>();

            //I should be able to change out "ball" with whatever I want to drop in. 
            persistentContent.DeviceTransformBinding = new TransformBinding(gameObj.GetInstanceID().ToString(), persistentContent.deviceData.prefabType);

            //**save the persistent data's id to match the transformbinding's id.

            persistentContent.DeviceTransformBinding.Bind(pcf, gameObj.transform);

            Debug.Log("Inside Create Content " + persistentContent.DeviceTransformBinding.Id + " Prefab type : " + persistentContent.DeviceTransformBinding.PrefabType);

            //ContentTap contentTap = persistentContent.GetComponent<ContentTap>();
            //contentTap.OnContentTap += OnContentDestroy;
            ++numPersistentContentCreated;

            //deviceManager.devicePrefabDictionary.Add(persistentContent.DeviceTransformBinding.Id, gameObj);
            //deviceManager.deviceDataDictionary.Add(persistentContent.DeviceTransformBinding.Id, 
            //    new PersistentDeviceData(persistentContent.DeviceTransformBinding.Id, gameObj.name, "DevicePrefab"));

            Debug.Log("Inside Create Content- persistentContent.deviceData id = " + persistentContent.deviceData.id);
            //for Data Serialization and saving
            deviceManager.deviceDataDictionary.Add(persistentContent.DeviceTransformBinding.Id, persistentContent.deviceData);

            //for device placement and PCF attatchment
            deviceManager.deviceDictionary.Add(persistentContent.DeviceTransformBinding.Id, gameObj);

            deviceManager.SaveDevices();

            _persistentContentMap.Add(persistentContent, "Created");
            #endif

            //Turn on DevicePlacement On
            myController.selectedGameObject = gameObj;

            Debug.Log("Turn On placement after placing device" + persistentContent.deviceData.id);
            myController.devicePlacementActive = true;
            myController.attachPoint.transform.position = gameObj.transform.position;

        }

        /// <summary>
        /// Destroys the given content and spawns another gameObject as a particle system effect.
        /// </summary>
        /// <param name="content">Content to destroy, assumed to be this content.</param>
        private void OnContentDestroy(GameObject content)
        {
            #if PLATFORM_LUMIN
            PersistentDevice persistentContent = content.GetComponent<PersistentDevice>();

            //** how does this get a specific dictionary entry if the key is the same for every entry? Maybe I dont know how dictionaries work.
            if (_persistentContentMap.ContainsKey(persistentContent))
            {
                string val = _persistentContentMap[persistentContent];

                if (val == "Created")
                {
                    --numPersistentContentCreated;
                }
                else if (val == "Regained")
                {
                    --numPersistentContentRegained;
                }

                _persistentContentMap.Remove(persistentContent);
            }
#endif
        }

        private void HandleOnFindAllPCFs(List<MLPersistentCoordinateFrames.PCF> allPCFs)
        {
#if PLATFORM_LUMIN
            numTotalPCFs = allPCFs.Count;
            numSingerUserSingleSessionPCFs = allPCFs.FindAll((MLPersistentCoordinateFrames.PCF pcf) => { return pcf.Type == MLPersistentCoordinateFrames.PCF.Types.SingleUserSingleSession; }).Count;
            numSingleUserMultiSessionPCFs = allPCFs.FindAll((MLPersistentCoordinateFrames.PCF pcf) => { return pcf.Type == MLPersistentCoordinateFrames.PCF.Types.SingleUserMultiSession; }).Count;
            numMultiUserMultiSessionPCFs = allPCFs.FindAll((MLPersistentCoordinateFrames.PCF pcf) => { return pcf.Type == MLPersistentCoordinateFrames.PCF.Types.MultiUserMultiSession; }).Count;
#endif
        }

        /// <summary>
        /// Listens for Bumper and Home Tap.
        /// </summary>
        /// <param name="controllerId">Id of the incoming controller.</param>
        /// <param name="button">Enum of the button that was pressed.</param>
        private void HandleControllerButtonDown(byte controllerId, MLInput.Controller.Button button)
        {
            if (!_controller.IsControllerValid(controllerId))
            {
                return;
            }

            //will no longer need the bumper press.
            #if PLATFORM_LUMIN
            if (button == MLInput.Controller.Button.Bumper && MLPersistentCoordinateFrames.IsLocalized)
            {
                Vector3 position = _controller.transform.position + _controller.transform.forward * _distance;
                //CreateDevicePCF(position, _controller.transform.rotation, "Prefab-Ball");
            }
            else if (button == MLInput.Controller.Button.HomeTap)
            {
                _pcfVisualizer.Toggle();
            }
            #endif
        }

        /// <summary>
        /// Handler when touchpad gesture begins.
        /// </summary>
        /// <param name="controllerId">Id of the incoming controller.</param>
        /// <param name="touchpadGesture">Class of which gesture was started.</param>
        private void HandleTouchpadGestureStart(byte controllerId, MLInput.Controller.TouchpadGesture touchpadGesture)
        {
            if (!_controller.IsControllerValid(controllerId))
            {
                return;
            }

#if PLATFORM_LUMIN
            if (touchpadGesture.Type == MLInput.Controller.TouchpadGesture.GestureType.RadialScroll)
            {
                _deleteAllInitiated = true;
                _deleteAllSequenceFrameCount = 0;
            }
#endif
        }

        /// <summary>
        /// Handler when touchpad gesture continues.
        /// </summary>
        /// <param name="controllerId">Id of the incoming controller.</param>
        /// <param name="touchpadGesture">Class of which gesture was continued.</param>
        private void HandleTouchpadGestureContinue(byte controllerId, MLInput.Controller.TouchpadGesture touchpadGesture)
        {
            if (!_controller.IsControllerValid(controllerId))
            {
                return;
            }

            if (_deleteAllInitiated)
            {
#if PLATFORM_LUMIN
                if (touchpadGesture.Type == MLInput.Controller.TouchpadGesture.GestureType.RadialScroll)
                {
                    ++_deleteAllSequenceFrameCount;
                    if (_deleteAllSequenceFrameCount >= _deleteAllSequenceMinFrames)
                    {
                        _deleteAllInitiated = false;
                        DeletePCFData();


                    }
                }
#endif
            }
        }

        /// <summary>
        /// Handler when touchpad gesture ends.
        /// </summary>
        /// <param name="controllerId">Id of the incoming controller.</param>
        /// <param name="touchpadGesture">Class of which gesture was ended.</param>
        private void HandleTouchpadGestureEnd(byte controllerId, MLInput.Controller.TouchpadGesture touchpadGesture)
        {
            if (!_controller.IsControllerValid(controllerId))
            {
                return;
            }

            if (_deleteAllInitiated)
            {
#if PLATFORM_LUMIN
                if (touchpadGesture.Type == MLInput.Controller.TouchpadGesture.GestureType.RadialScroll &&
                    _deleteAllSequenceFrameCount < _deleteAllSequenceMinFrames)
                {
                    _deleteAllInitiated = false;
                }
#endif
            }
        }

        public void DeletePCFData()
        {
            foreach (KeyValuePair<PersistentDevice, string> persistentContentPair in _persistentContentMap)
            {
                PersistentDevice persistentContent = persistentContentPair.Key;

                string val = _persistentContentMap[persistentContent];

                if (val == "Created")
                {
                    --numPersistentContentCreated;
                }
                else if (val == "Regained")
                {
                    --numPersistentContentRegained;
                }

                persistentContent.DestroyContent(persistentContent.gameObject);
            }

            _persistentContentMap.Clear();
        }
    }
}

