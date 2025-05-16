using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Scriptable Objects/PlayerAttributes")]
public class SOPlayerAttributes : ScriptableObject
{
    [SerializeField] private float horizontalMovementSpeed = 50.0f;
    [SerializeField] private Vector2 horizontalMovementRange = new Vector2(-80, 80);

    public float HorizontalMovementSpeed { get => horizontalMovementSpeed; }
    public Vector2 HorizontalMovementRange { get => horizontalMovementRange; }
}
