using UnityEngine;
using TMPro;

public class HasanatCounter : MonoBehaviour
{
    public static HasanatCounter instance; // تمكين الاستدعاء السريع من أي مكان
    public TextMeshProUGUI hasanatText;
    private int totalHasanat = 0;

    void Awake()
    {
        // إعداد الـ Singleton لضمان وجود عداد مركزي واحد فقط
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    // دالة لزيادة الحسنات وتحديث الشاشة تلقائياً
    public void AddHasanat(int amount)
    {
        totalHasanat += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        hasanatText.text = "Hasanat: " + totalHasanat;
    }
}