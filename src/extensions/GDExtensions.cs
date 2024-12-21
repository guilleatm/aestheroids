using Godot;
public static class GDExtensions
{
    public static Vector3 GetV3OnSphere(this RandomNumberGenerator randomNumberGenerator, float radius)
    {
        float theta = 2 * Mathf.Pi * randomNumberGenerator.Randf();
        float phi = Mathf.Pi * randomNumberGenerator.Randf();

        float x = Mathf.Sin(phi) * Mathf.Cos(theta) * radius;
        float y = Mathf.Sin(phi) * Mathf.Sin(theta) * radius;
        float z = Mathf.Cos(phi) * radius;

        return new Vector3(x, y, z);
    }
}