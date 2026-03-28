using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; 

public class DroneSurvival : MonoBehaviour
{
    [Header("ตั้งค่าเวลา")]
    public float timeLimit = 60f;
    public TextMeshProUGUI timerText;

    [Header("เอฟเฟกต์")]
    public GameObject explosionPrefab;

    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        timeLimit -= Time.deltaTime;
        timerText.text = "TIME: " + Mathf.RoundToInt(timeLimit).ToString();

        if (timeLimit <= 0)
        {
            // หมดเวลา = สั่งระเบิด และเกมโอเวอร์
            StartCoroutine(ExplodeAndGameOver("Time's Up!")); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Building"))
        {
            // ชนตึก = สั่งระเบิด และเกมโอเวอร์
            StartCoroutine(ExplodeAndGameOver("Crashed into a building!"));
        }
    }

    // ฟังก์ชันสำหรับบินทะลุเข้าจุดส่งของ (ชนะ)
    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        // ถ้าชนกับโซนที่แปะ Tag ว่า "Finish"
        if (other.gameObject.CompareTag("Finish"))
        {
            isDead = true; 
            Debug.Log("Mission Accomplished! Loading Win Scene...");
            SceneManager.LoadScene("Winner"); // วาร์ปไปหน้าชนะ
        }
    }

    IEnumerator ExplodeAndGameOver(string reason)
    {
        isDead = true; // ล็อกไม่ให้ขยับ
        Debug.Log("Game Over: " + reason);

        // 1. สั่งระเบิดตรงตำแหน่งโดรน
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        // 2. สั่งซ่อนโมเดลโดรน (ทั้งตัวแม่และตัวลูกที่เอามาสวมทับ)
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = false;
        }
        foreach (SkinnedMeshRenderer smr in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            smr.enabled = false;
        }

        // 3. รอ 1 วินาที เพื่อให้ผู้เล่นเห็นระเบิดสวยๆ
        yield return new WaitForSeconds(1f); 

        // 4. วาร์ปไปหน้า Game Over
        SceneManager.LoadScene("GameOver");
    }
}