namespace Schedule1EnhancedMod.Utils;

/// <summary>
/// Helper extensions for various types
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Safely get a component from a GameObject
    /// Logs an error if the component is not found
    /// </summary>
    public static T? SafeGetComponent<T>(this UnityEngine.GameObject gameObject) where T : UnityEngine.Component
    {
        var component = gameObject.GetComponent<T>();
        
        if (component == null)
        {
            Logger.Warning($"Component {typeof(T).Name} not found on GameObject {gameObject.name}");
        }
        
        return component;
    }
    
    /// <summary>
    /// Clamp a value between min and max
    /// </summary>
    public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0)
        {
            return min;
        }
        if (value.CompareTo(max) > 0)
        {
            return max;
        }
        return value;
    }
    
    /// <summary>
    /// Check if a string is null or empty
    /// </summary>
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }
    
    /// <summary>
    /// Shuffle a list in place using Fisher-Yates algorithm
    /// </summary>
    public static void Shuffle<T>(this IList<T> list)
    {
        var rng = new Random();
        int n = list.Count;
        
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
