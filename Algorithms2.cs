using System.Collections;
using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    public class Algorithms2
    {
        // Record should be indexed by the combination of pk_1 and pk_2 (each are part of the "primary key"). 
        public class Record
        {
            public int PK_1 { get; set; }
            public int PK_2 { get; set; }
            public string Value { get; set; }

            public struct Key
            {
                public readonly int Key1;
                public readonly int Key2;
                public Key(int PK_1, int PK_2)
                {
                    Key1 = PK_1;
                    Key2 = PK_2;
                }

            }
            public Key Keys
            {
                get; set;
            }
        }
        // Create an effecient cache of records as a field.
        // The structure of a cache should not be a .NET MemoryCache. Use your own data structure.
		//Did not create cache yet, but solved the first half as creating a data structure for the data. 
        public void LoadRecordsIntoCache(IEnumerable<Record> records)
        {
            var recordsHashTable = new Hashtable();
            foreach (Record record in records)
            {
                recordsHashTable.Add(record.Keys, record.Value);
            }


            //

        }

        public Record GetRecord(int pk_1, int pk_2)
        {
            // Implement GetRecord. Need to retrieve value from the cache. Retrieval should be very fast.

            return null;
        }

    }
}

