using UnityEngine;

/// <summary>
/// Kelas induk untuk seluruh objek yang dapat disentuh pemain.
/// Ditandai abstract: tidak dapat dipasang langsung ke GameObject,
/// harus diturunkan lebih dulu.
/// </summary>
public abstract class InteractiveObject : MonoBehaviour
{
    [Header("Pengaturan Umum")]
    [SerializeField] protected string displayName = "Objek";
    [SerializeField] protected int pointValue = 10;

    // Encapsulation: nilai dapat dibaca dari luar, tetapi hanya
    // class ini dan turunannya yang dapat mengubahnya.
    public int PointValue => pointValue;
    public string DisplayName => displayName;

    protected bool isActivated;

    /// <summary>
    /// Dipanggil saat objek disentuh. Tidak punya isi di sini —
    /// setiap turunan WAJIB menyediakan implementasinya sendiri.
    /// </summary>
    public abstract void OnInteract();

    /// <summary>
    /// Perilaku bawaan yang BOLEH ditimpa turunan.
    /// Perhatikan kata kunci virtual, bukan abstract.
    /// </summary>
    public virtual string GetDescription()
    {
        return $"{displayName} bernilai {pointValue} poin.";
    }

    protected void ReportInteraction()
    {
        isActivated = true;
        Debug.Log($"[Interaksi] {GetDescription()}");
    }
}