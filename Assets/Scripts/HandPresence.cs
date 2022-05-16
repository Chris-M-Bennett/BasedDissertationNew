using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerChars;
    [SerializeField] private GameObject handPrefab;
    private InputDevice _targetDevice;
    private GameObject _spawnedHand;
    private Animator handAnim;
    private static readonly int Trigger = Animator.StringToHash("Trigger");
    private static readonly int Grip = Animator.StringToHash("Grip");

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChars, devices);

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
            _spawnedHand = Instantiate(handPrefab,transform);
            handAnim = _spawnedHand.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnim.SetFloat(Trigger, triggerValue);
        }else
        {
            handAnim.SetFloat(Trigger, 0);  
        }
        
        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnim.SetFloat(Grip, gripValue);
        }else
        {
            handAnim.SetFloat(Grip, 0);  
        }
    }
}
