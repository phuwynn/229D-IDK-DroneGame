using UnityEngine;

public class RopeVisualizer : MonoBehaviour
{
    public Transform packageTransform; // เอาไว้รับตำแหน่งของกล่องพัสดุ
    private LineRenderer line;

    void Start()
    {
        // ดึงคอมโพเนนต์ Line Renderer มาใช้งาน
        line = GetComponent<LineRenderer>();
        line.positionCount = 2; // เชือกมี 2 ปลาย 
    }

    void Update()
    {
        // อัปเดตตำแหน่งจุดหัวและท้ายของเส้นเชือกทุกๆเฟรม
        if (packageTransform != null)
        {
            line.SetPosition(0, transform.position);       // จุดที่ 0 ติดอยู่กับ Drone
            line.SetPosition(1, packageTransform.position); // จุดที่ 1 ติดอยู่กับ Package
        }
    }
}