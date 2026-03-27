using UnityEngine;
using TMPro; 

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText; // ช่องสำหรับเชื่อมกับ UI บนจอ
    private float timer = 0f;

    void Update()
    {
        // นับเวลาเพิ่มขึ้นเรื่อยๆ ตามเวลาจริง
        timer += Time.deltaTime;

        // อัปเดตข้อความบนจอ 
        timeText.text = "Time: " + timer.ToString("F2") + " Sec";
    }
}