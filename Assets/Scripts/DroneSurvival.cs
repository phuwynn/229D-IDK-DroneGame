using UnityEngine;
using TMPro; // สำคัญมาก สำหรับจัดการ TextMeshPro
using UnityEngine.SceneManagement; // สำหรับเปลี่ยน Scene

public class DroneSurvival : MonoBehaviour
{
    [Header("ตั้งค่าเวลา")]
    public float timeLimit = 60f; // ให้เวลา 60 วินาที (แก้ใน Inspector ได้)
    public TextMeshProUGUI timerText;

    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        // นับเวลาถอยหลัง (ลบเวลาตามเฟรมเรตจริง)
        timeLimit -= Time.deltaTime;

        // อัปเดตตัวเลขบนหน้าจอ (แปลงเป็นตัวเลขจำนวนเต็ม)
        timerText.text = "TIME: " + Mathf.RoundToInt(timeLimit).ToString();

        // หมดเวลา = เกมโอเวอร์
        if (timeLimit <= 0)
        {
            TriggerGameOver("Time's Up!");
        }
    }

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อโดรนไปชนวัตถุอื่น
    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        // ถ้าชนวัตถุที่แปะป้ายชื่อว่า "Building" หรือ "Ground" (พื้น)
        if (collision.gameObject.CompareTag("Building"))
        {
            TriggerGameOver("Crashed into a building!");
        }
    }
    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อโดรนบินทะลุเข้า "เขตรู้ใจ" (Is Trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return; // ถ้าตายแล้ว ไม่รับรู้ชนะแล้ว

        // ถ้าสิ่งที่โดรนบินทะลุเข้ามา แปะป้ายชื่อว่า "Finish"
        if (other.gameObject.CompareTag("Finish"))
        {
            isDead = true; // ล็อกไม่ให้ขยับได้อีก
            Debug.Log("Mission Accomplished! Loading Win Scene...");
            
            // วาร์ปผู้เล่นไปหน้า Scene Winner ทันที!
            SceneManager.LoadScene("Winner");
        }
    }

    private void TriggerGameOver(string reason)
    {
        isDead = true;
        Debug.Log("Game Over: " + reason);
        
        // เตะผู้เล่นไปหน้า Game Over ที่เราทำเตรียมไว้เลย!
        SceneManager.LoadScene("GameOver");
    }
}