using UnityEngine;

public class PulsingArtifact : InteractiveObject
{
    [Header("Denyut")]
    [SerializeField] private float pulseSpeed = 2f;
    [SerializeField] private float pulseAmount = 0.25f;

    private Vector3 _baseScale;

    private void Awake()
    {
        // Mengurus diri sendiri — aman dilakukan di Awake.
        _baseScale = transform.localScale;
    }

    private void Update()
    {
        if (!isActivated) return;

        // Mathf.Sin menghasilkan nilai -1..1 yang berulang,
        // sehingga skala objek naik-turun secara halus.
        float factor = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = _baseScale * factor;
    }

    public override void OnInteract()
    {
        ReportInteraction();
    }
}