using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject storyPanel;
    public GameObject howToPlayPanel;
    public GameObject creditPanel;

    public void ClickStart()
    {
        storyPanel.SetActive(true); // เปิดหน้าต่างเนื้อเรื่อง
    }

    public void ClickHowToPlay()
    {
        howToPlayPanel.SetActive(true); // เปิดหน้าต่างสอนเล่น
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false); // ปิดหน้าต่างสอนเล่น
    }
    

    public void ClickExit()
    {
        Debug.Log("ออกจากเกม!");
        Application.Quit(); // ปิดเกม
    }

    public void ClickYes()
    {
        SceneManager.LoadScene("Scene1"); // ไปด่าน 1 
    }

    public void ClickNo()
    {
        SceneManager.LoadScene("GameOver"); // ไปหน้าแพ้
    }

    public void ClickCredit()
    {
        creditPanel.SetActive(true); // เปิดหน้าต่างเครดิต
    }

    public void CloseCredit()
    {
        creditPanel.SetActive(false); // ปิดหน้าต่างเครดิต
    }
}