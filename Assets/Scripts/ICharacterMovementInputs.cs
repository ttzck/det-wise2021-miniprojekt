using UnityEngine;

public interface ICharacterMovementInputs
{
    /// <summary>
    /// the character will move in this direction
    /// </summary>
    Vector2 MovementDirection { get; }
    
    /// <summary>
    /// the character will point at this position
    /// </summary>
    Vector2 RotationTarget { get; }
}