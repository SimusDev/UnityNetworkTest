using UnityEngine;

public static class ScriptableObjectExtension
{
    /// <summary>
    /// Создаёт и возвращает клонирование заданного ScriptableObject.
    /// </summary>
    /// <typeparam name="T">Тип клонируемого объекта.</typeparam>
    /// <param name="scriptableObject">Исходный ScriptableObject.</param>
    /// <returns>Независимая копия объекта.</returns>
    public static T Duplicate<T>(this T scriptableObject) where T : ScriptableObject
    {
        if (scriptableObject == null)
        {
            Debug.LogError($"ScriptableObject was null. Возвращаем объект по умолчанию {typeof(T)}.");
            return (T)ScriptableObject.CreateInstance(typeof(T));
        }
        T instance = Object.Instantiate(scriptableObject);
        instance.name = scriptableObject.name; // Удаляем "(Clone)" из имени
        return instance;
    }
}
