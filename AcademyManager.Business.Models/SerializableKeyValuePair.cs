using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models
{
    [Serializable]
    public class SerializableKeyValuePair<K, V>
    {
        public SerializableKeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
        }
        public K Key { get; set; }
        public V Value { get; set; }
    }
}
