using UnityEngine;
using StatePattern.Player;
[RequireComponent(typeof(StateManager))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private StateManager _stateManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        _stateManager = GetComponent<StateManager>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _stateManager.ChangeState(_stateManager._moveState);
        }
        else
        {
            _stateManager.ChangeState(_stateManager._idleState);
        }
    }
}