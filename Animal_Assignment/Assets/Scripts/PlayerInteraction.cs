using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject burger;
    public GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            {
                Instantiate(burger, hitInfo.point + (Vector3.up * 0.2f), Quaternion.identity);
            }
        }
    }

    public void spawnBurger()
    {
       
    }

    public void spawnBall ()
    {

    }
}
