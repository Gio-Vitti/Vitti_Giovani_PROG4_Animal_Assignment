using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CLickToMove : MonoBehaviour
{
    public NavMeshAgent navAgent;
    private InputSystem_Actions inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Attack.performed -= OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
        {
            navAgent.SetDestination(hitInfo.point);
        }
    }
}