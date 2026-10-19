using UnityEngine;
using UnityEngine.InputSystem; // Tambahkan namespace ini

public class TouchDispatcher : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private bool showDebugRay = true;

    private void Awake()
    {
        if (targetCamera == null) targetCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 screenPos = Vector2.zero;
        bool triggered = false;

        // Deteksi sentuhan (touch) atau klik mouse menggunakan New Input System
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            triggered = true;
        }
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            screenPos = Mouse.current.position.ReadValue();
            triggered = true;
        }

        if (triggered)
        {
            TryInteract(screenPos);
        }
    }

    private void TryInteract(Vector2 screenPos)
    {
        Ray ray = targetCamera.ScreenPointToRay(screenPos);

        if (showDebugRay)
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.TryGetComponent(out InteractiveObject interactive))
            {
                interactive.OnInteract();
            }
            else
            {
                Debug.Log($"[Touch] Mengenai {hit.collider.name}, bukan objek interaktif.");
            }
        }
        else
        {
            Debug.Log("[Touch] Tidak mengenai apa pun.");
        }
    }
}