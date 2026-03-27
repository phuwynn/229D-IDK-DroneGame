using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeliveryPoint : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("ส่งของสำเร็จ! เตรียมโหลด Scene 2");
            
        }
    }
}