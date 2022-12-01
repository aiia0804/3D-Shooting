using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    [SerializeField] float defaulutAngle = 60f;
    [SerializeField] float maximumIntensity = 30f;
    [SerializeField] Slider BatterySlider;

    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        myLight.spotAngle = Mathf.Clamp(myLight.spotAngle - angleDecay * Time.deltaTime, minimumAngle, myLight.spotAngle);
        myLight.intensity -= lightDecay * Time.deltaTime;
        BatterySlider.value = myLight.intensity;
    }
    public void Charge(float Charge)
    {
        myLight.intensity = Mathf.Clamp(myLight.intensity + Charge, 0f, maximumIntensity);
        myLight.spotAngle = defaulutAngle;
    }
}
