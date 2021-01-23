using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionayList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDict<int, string> myDict = new MyDict<int, string>();
            myDict.Add(1, "Yusuf");
            myDict.Add(2, "Enes");
            myDict.Add(3, "Aras");

            myDict.takeThemAll();
        }
    }
    public class MyDict<TKey, TValue>
    {
        TKey[] _keys; // Anahtar sözcükler tutulur.
        TValue[] _values; // değerlerin tutulacağı dizi
        TKey[] tempKeyArray = new TKey[0]; // Anahtar sözcükleri yedekleme (geçici)
        TValue[] tempValuesArray = new TValue[0]; // değerleri yedekleme (geçici)
       
        // Constructor
        public MyDict()
        {
            _keys = new TKey[0];
            _values = new TValue[0];
        }
        public void Add(TKey key,TValue value)
        {
            tempKeyArray = _keys;
            _keys = new TKey[_keys.Length + 1]; // Mevcut dizinin boyutundan 1 eleman fazla eleman alabilecek yeni bir dizi ürettik.

            tempValuesArray = _values;
            _values = new TValue[_values.Length + 1];
            for (int i = 0; i < tempKeyArray.Length; i++) // for ile asıl dizimize verileri yerleştiriyoruz.
            {
                _keys[i] = tempKeyArray[i];
                _values[i] = tempValuesArray[i];
            }
            _keys[_keys.Length - 1] = key; // Aktarma tamamlandıktan sonra, dizi sonunda oluşan 1 elemanlık boşluğa anahtar sözcüğümüzü ekliyoruz.
            _values[_values.Length - 1] = value; // Aktarma tamamlandıktan sonra, dizi sonunda oluşan 1 elemanlık boşluğa anahtar sözcüğümüzü ekliyoruz.
        }
        public void takeThemAll() // verileri yazdırma
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                Console.WriteLine("Keys: "+_keys[i]+ " ->" + " Values: "+_values[i]);
            }
        }
    }
}
