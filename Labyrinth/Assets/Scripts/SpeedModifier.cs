using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Custom Assets/Speed Modifier")]
public class SpeedModifier : ObjectItems
{
    public int speedModifier;

    public override void Use()
    {
        base.Use();
        ApplyEffect();
    }

    void ApplyEffect()
    {
        Character.instance.ModifySpeed(speedModifier);
    }
}