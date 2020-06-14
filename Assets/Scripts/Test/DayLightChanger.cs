using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayLightChanger : MonoBehaviour
{
    [SerializeField] private float TimeChangeSpeed = 0.05f;
    private float _dayTime = 0;
    private float _maxDayTime = 1;
    private Light2D _dayLight;

    private void Start()
    {
        _dayLight = gameObject.GetComponent<Light2D>();
    }

    private void Update()
    {
        _dayTime += Time.deltaTime * TimeChangeSpeed;
        if (_dayTime >= _maxDayTime) _dayTime = 0;
        ChangeLightState();
    }

    private void ChangeLightState()
    {
        _dayLight.intensity = GetLightIntensivety(_dayTime);
        _dayLight.color = GetColor(_dayTime);
    }

    private float GetLightIntensivety(float currentTime)
    {
        return Mathf.Clamp(Mathf.Sin(currentTime * 3), 0.2f, 0.6f);
    }

    private Color GetColor(float currentTime)
    {
        float min = 50;
        float power = Mathf.Sin(currentTime * 3);
        float red = power * min;
        Color color = new Color((red + (255 - min)) / 255, 1, 1);
        return color;
    }
}
