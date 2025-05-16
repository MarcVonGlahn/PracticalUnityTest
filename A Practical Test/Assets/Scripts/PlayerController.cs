using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private SOPlayerAttributes playerAttributes;

    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawn;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerHealthText;


    private Vector3 _initialPosition;

    private PlayerControl_Actions _playerControlActions;

    private InputAction _moveInput;



    private void Awake()
    {
        _playerControlActions = new PlayerControl_Actions();

        _initialPosition = transform.position;
    }


    private void OnEnable()
    {
        if (_playerControlActions == null)
            return;

        _moveInput = _playerControlActions.Player.Move;
        _moveInput.Enable();

        _playerControlActions.Player.Fire.performed += FireInputAction_Performed;
        _playerControlActions.Player.Fire.Enable();

        _playerControlActions.Player.Restart.performed += RestartInputAction_Performed;
        _playerControlActions.Player.Restart.Enable();

        _playerControlActions.Player.QuitGame.performed += QuitGameInputAction_Performed;
        _playerControlActions.Player.QuitGame.Enable();

        playerAttributes.PlayerHealth = playerAttributes.MaxPlayerHealth;
    }

    

    private void OnDisable()
    {
        _moveInput.Disable();
        _playerControlActions.Player.Fire.Disable();
        _playerControlActions.Player.Restart.Disable();
        _playerControlActions.Player.QuitGame.Disable();
    }


    private void Update()
    {
        if (_moveInput == null)
            return;

        float xInput = _moveInput.ReadValue<Vector2>().x;

        if (xInput == 0.0f)
            return;

        float newXCoordinate = Mathf.Clamp(
            transform.position.x + (xInput * Time.deltaTime * playerAttributes.HorizontalMovementSpeed),
            playerAttributes.HorizontalMovementRange.x,
            playerAttributes.HorizontalMovementRange.y
            );

        transform.position = new Vector3(newXCoordinate, _initialPosition.y, _initialPosition.z);
    }


    public void TakeDamage(float damageAmount)
    {
        playerAttributes.PlayerHealth -= damageAmount;

        if (playerHealthText != null)
            playerHealthText.text = $"Player Health: {Mathf.Ceil(playerAttributes.PlayerHealth)}";

        if (playerAttributes.PlayerHealth <= 0)
        {
            if (playerHealthText != null)
                playerHealthText.text = $"Player DIED!";

            Destroy(gameObject);
        }
    }


    private void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


    #region InputActionEvents
    private void FireInputAction_Performed(InputAction.CallbackContext obj)
    {
        GameObject newProjectile = Instantiate<GameObject>(projectilePrefab, projectileSpawn.position, Quaternion.identity);

        newProjectile.GetComponent<ProjectileControl>().Initialize(true, new Vector3(0, 0, 20.0f));
    }


    private void RestartInputAction_Performed(InputAction.CallbackContext obj)
    {
        RestartGame();
    }


    private void QuitGameInputAction_Performed(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }
    #endregion
}
