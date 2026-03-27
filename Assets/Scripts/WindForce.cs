using UnityEngine;

public class WindForce : MonoBehaviour
{
    // กำหนดความแรงและทิศทางลม (แกน X คือผลักไปทางขวา)
    public Vector3 windDirection = new Vector3(25f, 0f, 0f); 

    // ฟังก์ชันนี้จะทำงานตลอดเวลาที่โดรนบินอยู่ในกล่อง WindZone
    void OnTriggerStay(Collider other)
    {
        // เช็คว่าสิ่งที่บินเข้ามา มีระบบฟิสิกส์ (Rigidbody) ไหม
        Rigidbody rb = other.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            // ถ้ามี ก็จับเป่าปลิวไปตามทิศทางลม
            rb.AddForce(windDirection, ForceMode.Force);
        }
    }
}