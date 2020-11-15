using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance { get; private set; }

    [SerializeField] private float maxAngle;
    [SerializeField] private float maxOffset;

    [SerializeField] private float traumaDecrease;

    private float trauma;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        float offsetX = maxOffset * Shake * Random.Range(-1f, 1f);
        float offsetY = maxOffset * Shake * Random.Range(-1f, 1f);
        float angle = maxAngle * Shake * Random.Range(-1f, 1f);

        transform.position = originalPosition + new Vector3(offsetX, offsetY);
        transform.rotation = originalRotation * Quaternion.Euler(0, 0, angle);

        SetTrauma(trauma - traumaDecrease * Time.deltaTime);
    }

    public void AddTrauma(float addedTrauma)
    {
        SetTrauma(trauma + addedTrauma);
    }

    private void SetTrauma(float value)
    {
        trauma = Mathf.Clamp(value, 0, 1);
    }

    private float Shake => Mathf.Pow(trauma, 2);
}
