using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float targetAcceleration = 15f; // ตัวแปรความเร่ง (a) แนวราบ
    public float liftAcceleration = 25f;   // ตัวแปรความเร่ง (a) บินขึ้น
    private Rigidbody rb;

    void Start()
    {
        // ดึงระบบฟิสิกส์ในตัวโดรนมาใช้งาน
        rb = GetComponent<Rigidbody>();
    }

    // ต้องใช้ FixedUpdate สำหรับการคำนวณฟิสิกส์
    void FixedUpdate()
    {
        // 1. รับค่าปุ่ม WASD หรือลูกศร
        float moveH = Input.GetAxis("Horizontal"); // แกน X (ซ้าย-ขวา)
        float moveV = Input.GetAxis("Vertical");   // แกน Z (หน้า-หลัง)

        // 2. สร้าง Vector ความเร่ง (Acceleration)
        Vector3 acceleration = new Vector3(moveH, 0f, moveV) * targetAcceleration;

        // ถ้ากด Spacebar ให้เพิ่มความเร่งในแนวตั้ง (บินขึ้น)
        if (Input.GetKey(KeyCode.Space))
        {
            acceleration.y = liftAcceleration;
        }

        // 3. เข้าสูตรฟิสิกส์ F = ma (Force = Mass x Acceleration)
        Vector3 appliedForce = rb.mass * acceleration;

        // 4. นำผลลัพธ์ที่คำนวณได้ไปใช้ส่งแรงผลัก
        rb.AddForce(appliedForce);
    }
}