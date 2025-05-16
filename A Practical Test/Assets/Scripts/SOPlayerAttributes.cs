using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Scriptable Objects/PlayerAttributes")]
public class SOPlayerAttributes : ScriptableObject
{
    [Header("Player Attributes")]
    [SerializeField] private float playerHealth = 100.0f;
    [SerializeField] private float horizontalMovementSpeed = 50.0f;
    [SerializeField] private Vector2 horizontalMovementRange = new Vector2(-80, 80);


    public float PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public float HorizontalMovementSpeed { get => horizontalMovementSpeed; }
    public Vector2 HorizontalMovementRange { get => horizontalMovementRange; }
}
