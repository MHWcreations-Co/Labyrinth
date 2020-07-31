using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Custom Assets/Health Modifier")]
public class HealthModifier : ObjectItems
{
    public int healthModifier;

    public override void Use()
    {
        base.Use();
        ApplyEffect();
    }

    void ApplyEffect()
    {
        Character.instance.ModifyHealth(healthModifier);
    }
}