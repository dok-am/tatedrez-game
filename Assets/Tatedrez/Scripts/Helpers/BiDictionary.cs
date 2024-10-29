using System.Collections.Generic;

namespace Tatedrez.Helpers
{
    /// <summary>
    /// Simple Dictionary with unique values
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    public class BiDictionary<TKey, TValue>
    {

        private Dictionary<TKey, TValue> _straightDict;
        private Dictionary<TValue, TKey> _reversedDict;

        public BiDictionary(int capacity)
        {
            _straightDict = new Dictionary<TKey, TValue>(capacity);
            _reversedDict = new Dictionary<TValue, TKey>(capacity);
        }

        public TValue this[TKey key] { 
            get => _straightDict[key];
            set
            {
                _straightDict[key] = value;
                _reversedDict[value] = key;
            }
        }

        public void Add(TKey key, TValue value)
        {
            _straightDict.Add(key, value);
            _reversedDict.Add(value, key);
        }

        public void Remove(TKey key)
        {
            TValue value = _straightDict[key];
            _straightDict.Remove(key);
            _reversedDict.Remove(value);
        }

        public void Remove(TValue value)
        {
            TKey key = _reversedDict[value];
            _reversedDict.Remove(value);
            _straightDict.Remove(key);
        }

        public TKey GetKeyForValue(TValue value)
        {
            return _reversedDict[value];
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _straightDict.TryGetValue(key, out value);
        }
    }
}