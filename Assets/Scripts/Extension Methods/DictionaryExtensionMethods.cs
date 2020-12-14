using System;
using System.Collections.Generic;

public static class DictionaryExtensionMethods {

    public static TValue GetValueOrDefault<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) {

        TValue value;
        return dictionary.TryGetValue (key, out value) ? value : defaultValue;

    }

    public static TValue GetValueOrDefault<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> defaultValueProvider) {

        TValue value;
        return dictionary.TryGetValue (key, out value) ? value : defaultValueProvider ();

    }

    public static void Initialize<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TKey key) {

        if (!dictionary.ContainsKey (key)) dictionary[key] = Activator.CreateInstance<TValue> ();

    }

    public static void Initialize<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value) {

        if (!dictionary.ContainsKey (key)) dictionary[key] = value;

    }

    public static void Initialize<TKey, TValue> (this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueProvider) {

        if (!dictionary.ContainsKey (key)) dictionary[key] = valueProvider ();

    }

}
