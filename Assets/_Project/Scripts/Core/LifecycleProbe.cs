using UnityEngine;

/// <summary>
/// Mencatat setiap fase lifecycle ke Console beserta nomor frame-nya,
/// sehingga urutan pemanggilan dapat dibuktikan secara empiris.
/// </summary>
public class LifecycleProbe : MonoBehaviour
{
    [SerializeField] private string probeName = "Probe";

    private int _updateCount;
    private int _fixedUpdateCount;

    private void Awake()
        => Debug.Log($"[{probeName}] 1. Awake | frame {Time.frameCount}");

    private void OnEnable()
        => Debug.Log($"[{probeName}] 2. OnEnable | frame {Time.frameCount}");

    private void Start()
        => Debug.Log($"[{probeName}] 3. Start | frame {Time.frameCount}");

    private void Update()
    {
        _updateCount++;
        // Dibatasi tiga kali agar Console tidak dibanjiri ribuan baris.
        if (_updateCount <= 3)
            Debug.Log($"[{probeName}] 4. Update #{_updateCount} | frame {Time.frameCount}");
    }

    private void FixedUpdate()
    {
        _fixedUpdateCount++;
        if (_fixedUpdateCount <= 3)
            Debug.Log($"[{probeName}] 5. FixedUpdate #{_fixedUpdateCount} | frame {Time.frameCount}");
    }

    private void OnDisable()
        => Debug.Log($"[{probeName}] 6. OnDisable | frame {Time.frameCount}");

    private void OnDestroy()
        => Debug.Log($"[{probeName}] 7. OnDestroy | frame {Time.frameCount}");
}