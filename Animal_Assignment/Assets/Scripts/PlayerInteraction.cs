using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject burger;
    public GameObject ball;
    private Blackboard blackboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackboard = GetComponent<Blackboard>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && blackboard.GetVariableValue<float>("Food") <= 0)
        {
           SpawnBurger();
        }
    }

    public void SpawnBurger()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
        {
            Instantiate(burger, hitInfo.point + (Vector3.up * 0.2f), Quaternion.identity);
        }
    }

    public void spawnBall ()
    {

    }
}
