using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Data Pemain")]
    public int totalPoints = 0; // Menyimpan poin lintas scene

    private void Awake()
    {
        // Mengecek apakah sudah ada GameManager lain
        if (Instance != null && Instance != this)
        {
            // Jika sudah ada, hancurkan yang baru ini agar tidak duplikat
            Destroy(gameObject);
            return;
        }

        // Jika belum ada, jadikan ini sebagai instance utama
        Instance = this;
        
        // Memastikan objek ini tidak dihancurkan saat pindah scene
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log($"[GameManager] Poin bertambah. Total poin sekarang: {totalPoints}");
    }
}