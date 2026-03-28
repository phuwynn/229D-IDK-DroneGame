using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void BackToMenu()
    {
        // เตะกลับไปหน้าแรก
        SceneManager.LoadScene("MainMenu"); 
    }

    public void GoToCredits()
    {
        // โหลดไปหน้าเครดิต
        SceneManager.LoadScene("Credits"); 
    }
}