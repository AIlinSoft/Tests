// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace System.Collections.Generic
{
    public static unsafe partial class Unsafe
    {
        /// <summary>
        /// Returns the size of an object of the given type parameter.
        /// </summary>
    //    [Intrinsic]
    //    [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>()
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
#endif
            throw new PlatformNotSupportedException();

            // sizeof !!0
            // ret
        }

        /// <summary>
        /// Casts the given object to the specified type, performs no dynamic type checking.
        /// </summary>
    //    [Intrinsic]
    //    [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: NotNullIfNotNull("value")]
        public static T As<T>(object? value) where T : class?
        {
            throw new PlatformNotSupportedException();

            // ldarg.0
            // ret
        }

        /// <summary>
        /// Reinterprets the given reference as a reference to a value of type <typeparamref name="TTo"/>.
        /// </summary>
      //  [Intrinsic]
      //  [NonVersionable]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ref TTo As<TFrom, TTo>(ref TFrom source)
        //{
        //    return System.Runtime.CompilerServices.Unsafe.As<byte, TTo>(ref *(byte*)source);
        //    return System.Runtime.CompilerServices.Unsafe.As(source);
        //    throw new PlatformNotSupportedException();

        //    // ldarg.0
        //    // ret
        //}

        /// <summary>
        /// Adds an element offset to the given reference.
        /// </summary>
     //   [Intrinsic]
     //   [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(ref T source, int elementOffset)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            return ref AddByteOffset(ref source, (IntPtr)(elementOffset * (int)SizeOf<T>()));
#endif
        }

        /// <summary>
        /// Adds an element offset to the given reference.
        /// </summary>
     //   [Intrinsic]
     //   [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(ref T source, IntPtr elementOffset)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            return ref AddByteOffset(ref source, (IntPtr)((int)elementOffset * (int)SizeOf<T>()));
#endif
        }

        /// <summary>
        /// Adds an element offset to the given pointer.
        /// </summary>
       // [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Add<T>(void* source, int elementOffset)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            return (byte*)source + (elementOffset * (int)SizeOf<T>());
#endif
        }

#if TARGET_64BIT
        /// <summary>
        /// Adds an element offset to the given reference.
        /// </summary>
        [Intrinsic]
        [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ref T Add<T>(ref T source, nint elementOffset)
        {
            return ref Unsafe.Add(ref source, (IntPtr)(void*)elementOffset);
        }
#endif

        /// <summary>
        /// Adds an byte offset to the given reference.
        /// </summary>
     //   [Intrinsic]
     //   [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ref T AddByteOffset<T>(ref T source, uint byteOffset)
        {
            return ref AddByteOffset(ref source, (IntPtr)(void*)byteOffset);
        }

        /// <summary>
        /// Determines whether the specified references point to the same location.
        /// </summary>
      //  [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreSame<T>(ref T left, ref T right)
        {
            throw new PlatformNotSupportedException();

            // ldarg.0
            // ldarg.1
            // ceq
            // ret
        }

        /// <summary>
        /// Determines whether the memory address referenced by <paramref name="left"/> is greater than
        /// the memory address referenced by <paramref name="right"/>.
        /// </summary>
        /// <remarks>
        /// This check is conceptually similar to "(void*)(&amp;left) &gt; (void*)(&amp;right)".
        /// </remarks>
     //   [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressGreaterThan<T>(ref T left, ref T right)
        {
            throw new PlatformNotSupportedException();

            // ldarg.0
            // ldarg.1
            // cgt.un
            // ret
        }

        /// <summary>
        /// Determines whether the memory address referenced by <paramref name="left"/> is less than
        /// the memory address referenced by <paramref name="right"/>.
        /// </summary>
        /// <remarks>
        /// This check is conceptually similar to "(void*)(&amp;left) &lt; (void*)(&amp;right)".
        /// </remarks>
     //   [Intrinsic]
     //   [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressLessThan<T>(ref T left, ref T right)
        {
            throw new PlatformNotSupportedException();

            // ldarg.0
            // ldarg.1
            // clt.un
            // ret
        }

        /// <summary>
        /// Initializes a block of memory at the given location with a given initial value
        /// without assuming architecture dependent alignment of the address.
        /// </summary>
       // [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount)
        {
            for (uint i = 0; i < byteCount; i++)
                AddByteOffset(ref startAddress, i) = value;
        }

        /// <summary>
        /// Reads a value of type <typeparamref name="T"/> from the given location.
        /// </summary>
      //  [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadUnaligned<T>(void* source)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            return System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref *(byte*)source);
#endif
        }

        /// <summary>
        /// Reads a value of type <typeparamref name="T"/> from the given location.
        /// </summary>
       // [Intrinsic]
        //[NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadUnaligned<T>(ref byte source)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            return System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref source);
#endif
        }

        /// <summary>
        /// Writes a value of type <typeparamref name="T"/> to the given location.
        /// </summary>
      //  [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUnaligned<T>(void* destination, T value)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref *(byte*)destination) = value;
#endif
        }

        /// <summary>
        /// Writes a value of type <typeparamref name="T"/> to the given location.
        /// </summary>
       // [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUnaligned<T>(ref byte destination, T value)
        {
#if CORECLR
            typeof(T).ToString(); // Type token used by the actual method body
            throw new PlatformNotSupportedException();
#else
            System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref destination) = value;
#endif
        }

        /// <summary>
        /// Adds an byte offset to the given reference.
        /// </summary>
      //  [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AddByteOffset<T>(ref T source, IntPtr byteOffset)
        {
            // This method is implemented by the toolchain
            throw new PlatformNotSupportedException();

            // ldarg.0
            // ldarg.1
            // add
            // ret
        }

        /// <summary>
        /// Reads a value of type <typeparamref name="T"/> from the given location.
        /// </summary>
       // [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(void* source)
        {
            return System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref *(byte*)source);
        }

        /// <summary>
        /// Reads a value of type <typeparamref name="T"/> from the given location.
        /// </summary>
      //  [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(ref byte source)
        {
            return System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref source);
        }

        /// <summary>
        /// Writes a value of type <typeparamref name="T"/> to the given location.
        /// </summary>
     //   [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(void* destination, T value)
        {
            System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref *(byte*)destination) = value;
        }

        /// <summary>
        /// Writes a value of type <typeparamref name="T"/> to the given location.
        /// </summary>
    //    [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(ref byte destination, T value)
        {
            System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref destination) = value;
        }

        /// <summary>
        /// Reinterprets the given location as a reference to a value of type <typeparamref name="T"/>.
        /// </summary>
     //   [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AsRef<T>(void* source)
        {
            return ref System.Runtime.CompilerServices.Unsafe.As<byte, T>(ref *(byte*)source);

          //  return ref Unsafe.As<byte, T>(ref *(byte*)source);
        }

        /// <summary>
        /// Reinterprets the given location as a reference to a value of type <typeparamref name="T"/>.
        /// </summary>
       // [Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AsRef<T>(in T source)
        {
            throw new PlatformNotSupportedException();
        }

        /// <summary>
        /// Determines the byte offset from origin to target from the given references.
        /// </summary>
        //[Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ByteOffset<T>(ref T origin, ref T target)
        {
            throw new PlatformNotSupportedException();
        }

        /// <summary>
        /// Returns a by-ref to type <typeparamref name="T"/> that is a null reference.
        /// </summary>
        //[Intrinsic]
       // [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T NullRef<T>()
        {
            return ref Unsafe.AsRef<T>(null);

            // ldc.i4.0
            // conv.u
            // ret
        }

        /// <summary>
        /// Returns if a given by-ref to type <typeparamref name="T"/> is a null reference.
        /// </summary>
        /// <remarks>
        /// This check is conceptually similar to "(void*)(&amp;source) == nullptr".
        /// </remarks>
      //  [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullRef<T>(ref T source)
        {
            return System.Runtime.CompilerServices.Unsafe.AsPointer(ref source) == null;

            // ldarg.0
            // ldc.i4.0
            // conv.u
            // ceq
            // ret
        }

        /// <summary>
        /// Bypasses definite assignment rules by taking advantage of <c>out</c> semantics.
        /// </summary>
      //  [Intrinsic]
      //  [NonVersionable]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInit<T>(out T value)
        {
            throw new PlatformNotSupportedException();

            // ret
        }
    }

    internal static class HashHelpers
    {

#if FEATURE_RANDOMIZED_STRING_HASHING
        public const int HashCollisionThreshold = 100;
        public static bool s_UseRandomizedStringHashing = String.UseRandomizedHashing();
#endif

        // Table of prime numbers to use as hash table sizes. 
        // A typical resize algorithm would pick the smallest prime number in this array
        // that is larger than twice the previous capacity. 
        // Suppose our Hashtable currently has capacity x and enough elements are added 
        // such that a resize needs to occur. Resizing first computes 2x then finds the 
        // first prime in the table greater than 2x, i.e. if primes are ordered 
        // p_1, p_2, ..., p_i, ..., it finds p_n such that p_n-1 < 2x < p_n. 
        // Doubling is important for preserving the asymptotic complexity of the 
        // hashtable operations such as add.  Having a prime guarantees that double 
        // hashing does not lead to infinite loops.  IE, your hash function will be 
        // h1(key) + i*h2(key), 0 <= i < size.  h2 and the size must be relatively prime.
        public static readonly int[] primes = {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369};

        // Used by Hashtable and Dictionary's SeralizationInfo .ctor's to store the SeralizationInfo
        // object until OnDeserialization is called.
        private static ConditionalWeakTable<object, SerializationInfo> s_SerializationInfoTable;

        internal static ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable
        {
            get
            {
                if (s_SerializationInfoTable == null)
                {
                    ConditionalWeakTable<object, SerializationInfo> newTable = new ConditionalWeakTable<object, SerializationInfo>();
                    Interlocked.CompareExchange(ref s_SerializationInfoTable, newTable, null);
                }

                return s_SerializationInfoTable;
            }

        }

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) != 0)
            {
                int limit = (int)Math.Sqrt(candidate);
                for (int divisor = 3; divisor <= limit; divisor += 2)
                {
                    if ((candidate % divisor) == 0)
                        return false;
                }
                return true;
            }
            return (candidate == 2);
        }
        internal const Int32 HashPrime = 101;
        public static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException("Arg_HTCapacityOverflow");
           
            for (int i = 0; i < primes.Length; i++)
            {
                int prime = primes[i];
                if (prime >= min) return prime;
            }

            //outside of our predefined table. 
            //compute the hard way. 
            for (int i = (min | 1); i < Int32.MaxValue; i += 2)
            {
                if (IsPrime(i) && ((i - 1) % HashPrime != 0))
                    return i;
            }
            return min;
        }

        public static int GetMinPrime()
        {
            return primes[0];
        }

        // Returns size of hashtable to grow to.
        public static int ExpandPrime(int oldSize)
        {
            int newSize = 2 * oldSize;

            // Allow the hashtables to grow to maximum possible size (~2G elements) before encoutering capacity overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            if ((uint)newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
            {
                return MaxPrimeArrayLength;
            }

            return GetPrime(newSize);
        }


        // This is the maximum prime smaller than Array.MaxArrayLength
        public const int MaxPrimeArrayLength = 0x7FEFFFFD;

#if FEATURE_RANDOMIZED_STRING_HASHING
        public static bool IsWellKnownEqualityComparer(object comparer)
        {
            return (comparer == null || comparer == System.Collections.Generic.EqualityComparer<string>.Default || comparer is IWellKnownStringEqualityComparer); 
        }
 
        public static IEqualityComparer GetRandomizedEqualityComparer(object comparer)
        {
            Contract.Assert(comparer == null || comparer == System.Collections.Generic.EqualityComparer<string>.Default || comparer is IWellKnownStringEqualityComparer); 
 
            if(comparer == null) {
                return new System.Collections.Generic.RandomizedObjectEqualityComparer();
            } 
 
            if(comparer == System.Collections.Generic.EqualityComparer<string>.Default) {
                return new System.Collections.Generic.RandomizedStringEqualityComparer();
            }
 
            IWellKnownStringEqualityComparer cmp = comparer as IWellKnownStringEqualityComparer;
 
            if(cmp != null) {
                return cmp.GetRandomizedEqualityComparer();
            }
 
            Contract.Assert(false, "Missing case in GetRandomizedEqualityComparer!");
 
            return null;
        }
 
        public static object GetEqualityComparerForSerialization(object comparer)
        {
            if(comparer == null)
            {
                return null;
            }
 
            IWellKnownStringEqualityComparer cmp = comparer as IWellKnownStringEqualityComparer;
 
            if(cmp != null)
            {
                return cmp.GetEqualityComparerForSerialization();
            }
 
            return comparer;
        }
 
        private const int bufferSize = 1024;
        private static RandomNumberGenerator rng;
        private static byte[] data;
        private static int currentIndex = bufferSize;
        private static readonly object lockObj = new Object();
 
        internal static long GetEntropy() 
        {
            lock(lockObj) {
                long ret;
 
                if(currentIndex == bufferSize) 
                {
                    if(null == rng)
                    {
                        rng = RandomNumberGenerator.Create();
                        data = new byte[bufferSize];
                        Contract.Assert(bufferSize % 8 == 0, "We increment our current index by 8, so our buffer size must be a multiple of 8");
                    }
 
                    rng.GetBytes(data);
                    currentIndex = 0;
                }
 
                ret = BitConverter.ToInt64(data, currentIndex);
                currentIndex += 8;
 
                return ret;
            }
        }
#endif // FEATURE_RANDOMIZED_STRING_HASHING
    }
    [Serializable] // Required for compatibility with .NET Core 2.0 as we exposed the NonRandomizedStringEqualityComparer inside the serialization blob
    // Needs to be public to support binary serialization compatibility
    public sealed class NonRandomizedStringEqualityComparer : EqualityComparer<string?>, ISerializable
    {
        internal static new IEqualityComparer<string?> Default { get; } = new NonRandomizedStringEqualityComparer();

        private NonRandomizedStringEqualityComparer() { }

        // This is used by the serialization engine.
        private NonRandomizedStringEqualityComparer(SerializationInfo information, StreamingContext context) { }

        public sealed override bool Equals(string? x, string? y) => string.Equals(x, y);

        public sealed override int GetHashCode(string? obj) => obj.GetHashCode();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // We are doing this to stay compatible with .NET Framework.

        }
        
    }

    /// <summary>
    /// Used internally to control behavior of insertion into a <see cref="Dictionary{int, TValue}"/>.
    /// </summary>
    internal enum InsertionBehavior : byte
    {
        /// <summary>
        /// The default insertion behavior.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that an existing entry with the same key should be overwritten if encountered.
        /// </summary>
        OverwriteExisting = 1,

        /// <summary>
        /// Specifies that if an existing entry with the same key is encountered, an exception should be thrown.
        /// </summary>
        ThrowOnExisting = 2
    }

    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class DictionaryIntTest<TValue> : IDictionary<int, TValue>, IDictionary, IReadOnlyDictionary<int, TValue>, ISerializable, IDeserializationCallback 
    {
        private struct Entry
        {
            public uint hashCode;
            // 0-based index of next entry in chain: -1 means end of chain
            // also encodes whether this entry _itself_ is part of the free list by changing sign and subtracting 3,
            // so -2 means end of free list, -3 means index 0 but on free list, -4 means index 1 but on free list, etc.
            public int next;
            public int key;           // Key of entry
            public TValue value;         // Value of entry
        }

        private int[]? _buckets;
        private Entry[]? _entries;
#if TARGET_64BIT
        private ulong _fastModMultiplier;
#endif
        private int _count;
        private int _freeList;
        private int _freeCount;
        private int _version;
        private IEqualityComparer<int>? _comparer;
        private KeyCollection? _keys;
        private ValueCollection? _values;
        private const int StartOfFreeList = -3;

        // constants for serialization
        private const string VersionName = "Version"; // Do not rename (binary serialization)
        private const string HashSizeName = "HashSize"; // Do not rename (binary serialization). Must save buckets.Length
        private const string KeyValuePairsName = "KeyValuePairs"; // Do not rename (binary serialization)
        private const string ComparerName = "Comparer"; // Do not rename (binary serialization)

        public DictionaryIntTest() : this(0, null) { }

        public DictionaryIntTest(int capacity) : this(capacity, null) { }

        public DictionaryIntTest(IEqualityComparer<int>? comparer) : this(0, comparer) { }

        public DictionaryIntTest(int capacity, IEqualityComparer<int>? comparer)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");
            if (capacity > 0) Initialize(capacity);
            if (comparer != null && comparer != EqualityComparer<int>.Default) // first check for null to avoid forcing default comparer instantiation unnecessarily
            {
                _comparer = comparer;
            }

            if (typeof(int) == typeof(string) && _comparer == null)
            {
                // To start, move off default comparer for string which is randomised
                _comparer = (IEqualityComparer<int>)NonRandomizedStringEqualityComparer.Default;
            }
        }

        public DictionaryIntTest(IDictionary<int, TValue> dictionary) : this(dictionary, null) { }

        public DictionaryIntTest(IDictionary<int, TValue> dictionary, IEqualityComparer<int>? comparer) :
            this(dictionary != null ? dictionary.Count : 0, comparer)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("ExceptionArgument.dictionary");
            }

            // It is likely that the passed-in dictionary is DictionaryIntTest<int,TValue>. When this is the case,
            // avoid the enumerator allocation and overhead by looping through the entries array directly.
            // We only do this when dictionary is DictionaryIntTest<int,TValue> and not a subclass, to maintain
            // back-compat with subclasses that may have overridden the enumerator behavior.
            if (dictionary.GetType() == typeof(DictionaryIntTest<TValue>))
            {
                DictionaryIntTest<TValue> d = (DictionaryIntTest<TValue>)dictionary;
                int count = d._count;
                Entry[]? entries = d._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries![i].next >= -1)
                    {
                        Add(entries[i].key, entries[i].value);
                    }
                }
                return;
            }

            foreach (KeyValuePair<int, TValue> pair in dictionary)
            {
                Add(pair.Key, pair.Value);
            }
        }

        public DictionaryIntTest(IEnumerable<KeyValuePair<int, TValue>> collection) : this(collection, null) { }

        public DictionaryIntTest(IEnumerable<KeyValuePair<int, TValue>> collection, IEqualityComparer<int>? comparer) :
            this((collection as ICollection<KeyValuePair<int, TValue>>)?.Count ?? 0, comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("ExceptionArgument.collection");
            }

            foreach (KeyValuePair<int, TValue> pair in collection)
            {
                Add(pair.Key, pair.Value);
            }
        }

        protected DictionaryIntTest(SerializationInfo info, StreamingContext context)
        {
            // We can't do anything with the keys and values until the entire graph has been deserialized
            // and we have a resonable estimate that GetHashCode is not going to fail.  For the time being,
            // we'll just cache this.  The graph is not valid until OnDeserialization has been called.
            HashHelpers.SerializationInfoTable.Add(this, info);
        }

        public IEqualityComparer<int> Comparer =>
            (_comparer == null || _comparer is NonRandomizedStringEqualityComparer) ?
                EqualityComparer<int>.Default :
                _comparer;

        public int Count => _count - _freeCount;

        public KeyCollection Keys => _keys ??= new KeyCollection(this);

        ICollection<int> IDictionary<int, TValue>.Keys => _keys ??= new KeyCollection(this);

        IEnumerable<int> IReadOnlyDictionary<int, TValue>.Keys => _keys ??= new KeyCollection(this);

        public ValueCollection Values => _values ??= new ValueCollection(this);

        ICollection<TValue> IDictionary<int, TValue>.Values => _values ??= new ValueCollection(this);

        IEnumerable<TValue> IReadOnlyDictionary<int, TValue>.Values => _values ??= new ValueCollection(this);

        public TValue this[int key]
        {
            get
            {
                ref TValue value = ref FindValue(key);
                if (!Unsafe.IsNullRef(ref value))
                {
                    return value;
                }
                throw new KeyNotFoundException("key");
                return default;
            }
            set
            {
                bool modified = TryInsert(key, value, InsertionBehavior.OverwriteExisting);
                Debug.Assert(modified);
            }
        }

        public void Add(int key, TValue value)
        {
            bool modified = TryInsert(key, value, InsertionBehavior.ThrowOnExisting);
            Debug.Assert(modified); // If there was an existing key and the Add failed, an exception will already have been thrown.
        }

        void ICollection<KeyValuePair<int, TValue>>.Add(KeyValuePair<int, TValue> keyValuePair)
            => Add(keyValuePair.Key, keyValuePair.Value);

        bool ICollection<KeyValuePair<int, TValue>>.Contains(KeyValuePair<int, TValue> keyValuePair)
        {
            ref TValue value = ref FindValue(keyValuePair.Key);
            if (!Unsafe.IsNullRef(ref value) && EqualityComparer<TValue>.Default.Equals(value, keyValuePair.Value))
            {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<int, TValue>>.Remove(KeyValuePair<int, TValue> keyValuePair)
        {
            ref TValue value = ref FindValue(keyValuePair.Key);
            if (!Unsafe.IsNullRef(ref value) && EqualityComparer<TValue>.Default.Equals(value, keyValuePair.Value))
            {
                Remove(keyValuePair.Key);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            int count = _count;
            if (count > 0)
            {
                Debug.Assert(_buckets != null, "_buckets should be non-null");
                Debug.Assert(_entries != null, "_entries should be non-null");

                Array.Clear(_buckets, 0, _buckets.Length);

                _count = 0;
                _freeList = -1;
                _freeCount = 0;
                Array.Clear(_entries, 0, count);
            }
        }
        /// <summary>
        /// Returns if a given by-ref to type <typeparamref name="T"/> is a null reference.
        /// </summary>
        /// <remarks>
        /// This check is conceptually similar to "(void*)(&amp;source) == nullptr".
        /// </remarks>
        //[Intrinsic]
        //[NonVersionable]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsNullRef<T>(ref T source)
        //{
        //    return Unsafe.AsPointer(ref source) == null;

        //    // ldarg.0
        //    // ldc.i4.0
        //    // conv.u
        //    // ceq
        //    // ret
        //}
        public bool ContainsKey(int key)
            => !Unsafe.IsNullRef(ref FindValue(key));

        public bool ContainsValue(TValue value)
        {
            Entry[]? entries = _entries;
            if (value == null)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (entries![i].next >= -1 && entries[i].value == null) return true;
                }
            }
            else
            {
                if (default(TValue) != null)
                {
                    // ValueType: Devirtualize with EqualityComparer<TValue>.Default intrinsic
                    for (int i = 0; i < _count; i++)
                    {
                        if (entries![i].next >= -1 && EqualityComparer<TValue>.Default.Equals(entries[i].value, value)) return true;
                    }
                }
                else
                {
                    // Object type: Shared Generic, EqualityComparer<TValue>.Default won't devirtualize
                    // https://github.com/dotnet/coreclr/issues/17273
                    // So cache in a local rather than get EqualityComparer per loop iteration
                    EqualityComparer<TValue> defaultComparer = EqualityComparer<TValue>.Default;
                    for (int i = 0; i < _count; i++)
                    {
                        if (entries![i].next >= -1 && defaultComparer.Equals(entries[i].value, value)) return true;
                    }
                }
            }
            return false;
        }

        private void CopyTo(KeyValuePair<int, TValue>[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("ExceptionArgument.array");
            }

            if ((uint)index > (uint)array.Length)
            {
                throw new ArgumentOutOfRangeException("NeedNonNegNumException");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
            }

            int count = _count;
            Entry[]? entries = _entries;
            for (int i = 0; i < count; i++)
            {
                if (entries![i].next >= -1)
                {
                    array[index++] = new KeyValuePair<int, TValue>(entries[i].key, entries[i].value);
                }
            }
        }

        public Enumerator GetEnumerator()
            => new Enumerator(this, Enumerator.KeyValuePair);

        IEnumerator<KeyValuePair<int, TValue>> IEnumerable<KeyValuePair<int, TValue>>.GetEnumerator()
            => new Enumerator(this, Enumerator.KeyValuePair);

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("ExceptionArgument.info");
            }

            info.AddValue(VersionName, _version);
            info.AddValue(ComparerName, _comparer ?? EqualityComparer<int>.Default, typeof(IEqualityComparer<int>));
            info.AddValue(HashSizeName, _buckets == null ? 0 : _buckets.Length); // This is the length of the bucket array

            if (_buckets != null)
            {
                var array = new KeyValuePair<int, TValue>[Count];
                CopyTo(array, 0);
                info.AddValue(KeyValuePairsName, array, typeof(KeyValuePair<int, TValue>[]));
            }
        }

        private ref TValue FindValue(int key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }
            ref Entry entry = ref Unsafe.NullRef<Entry>();
            if (_buckets != null)
            {
                Debug.Assert(_entries != null, "expected entries to be != null");
                IEqualityComparer<int>? comparer = _comparer;
                if (comparer == null)
                {
                    uint hashCode = (uint)key.GetHashCode();
                    int i = GetBucket(hashCode);
                    Entry[]? entries = _entries;
                    uint collisionCount = 0;
                    if (default(int) != null)
                    {
                        // ValueType: Devirtualize with EqualityComparer<TValue>.Default intrinsic

                        // Value in _buckets is 1-based; subtract 1 from i. We do it here so it fuses with the following conditional.
                        i--;
                        do
                        {
                            // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                            // Test in if to drop range check for following array access
                            if ((uint)i >= (uint)entries.Length)
                            {
                                goto ReturnNotFound;
                            }

                            entry = ref entries[i];
                            //if (entry.hashCode == hashCode && EqualityComparer<int>.Default.Equals(entry.key, key))
                            if (entry.hashCode == hashCode && entry.key == key)
                            {
                                    goto ReturnFound;
                            }

                            i = entry.next;

                            collisionCount++;
                        } while (collisionCount <= (uint)entries.Length);
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        goto ConcurrentOperation;
                    }
                    else
                    {
                        // Object type: Shared Generic, EqualityComparer<TValue>.Default won't devirtualize
                        // https://github.com/dotnet/coreclr/issues/17273
                        // So cache in a local rather than get EqualityComparer per loop iteration
                        EqualityComparer<int> defaultComparer = EqualityComparer<int>.Default;

                        // Value in _buckets is 1-based; subtract 1 from i. We do it here so it fuses with the following conditional.
                        i--;
                        do
                        {
                            // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                            // Test in if to drop range check for following array access
                            if ((uint)i >= (uint)entries.Length)
                            {
                                goto ReturnNotFound;
                            }

                            entry = ref entries[i];
                            if (entry.hashCode == hashCode && defaultComparer.Equals(entry.key, key))
                            {
                                goto ReturnFound;
                            }

                            i = entry.next;

                            collisionCount++;
                        } while (collisionCount <= (uint)entries.Length);
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        goto ConcurrentOperation;
                    }
                }
                else
                {
                    //  uint hashCode = (uint)comparer.GetHashCode(key);
                    uint hashCode = (uint)key.GetHashCode();
                    int i = GetBucket(hashCode);
                    Entry[]? entries = _entries;
                    uint collisionCount = 0;
                    // Value in _buckets is 1-based; subtract 1 from i. We do it here so it fuses with the following conditional.
                    i--;
                    do
                    {
                        // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                        // Test in if to drop range check for following array access
                        if ((uint)i >= (uint)entries.Length)
                        {
                            goto ReturnNotFound;
                        }

                        entry = ref entries[i];
                        //  if (entry.hashCode == hashCode && comparer.Equals(entry.key, key))
                        if (entry.hashCode == hashCode && entry.key == key)
                        {
                            goto ReturnFound;
                        }

                        i = entry.next;

                        collisionCount++;
                    } while (collisionCount <= (uint)entries.Length);
                    // The chain of entries forms a loop; which means a concurrent update has happened.
                    // Break out of the loop and throw, rather than looping forever.
                    goto ConcurrentOperation;
                }
            }

            goto ReturnNotFound;

        ConcurrentOperation:
            throw new InvalidOperationException("ConcurrentOperationsNotSupported");
        ReturnFound:
            ref TValue value = ref entry.value;
        Return:
            return ref value;
        ReturnNotFound:
            value = ref Unsafe.NullRef<TValue>();
            goto Return;
        }

        private int Initialize(int capacity)
        {
            int size = HashHelpers.GetPrime(capacity);
            int[] buckets = new int[size];
            Entry[] entries = new Entry[size];

            // Assign member variables after both arrays allocated to guard against corruption from OOM if second fails
            _freeList = -1;
#if TARGET_64BIT
            _fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)size);
#endif
            _buckets = buckets;
            _entries = entries;

            return size;
        }

        private bool TryInsert(int key, TValue value, InsertionBehavior behavior)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }

            if (_buckets == null)
            {
                Initialize(0);
            }
            Debug.Assert(_buckets != null);

            Entry[]? entries = _entries;
            Debug.Assert(entries != null, "expected entries to be non-null");

            IEqualityComparer<int>? comparer = _comparer;
            uint hashCode = (uint)((comparer == null) ? key.GetHashCode() : comparer.GetHashCode(key));

            uint collisionCount = 0;
            ref int bucket = ref GetBucket(hashCode);
            // Value in _buckets is 1-based
            int i = bucket - 1;

            if (comparer == null)
            {
                if (default(int) != null)
                {
                    // ValueType: Devirtualize with EqualityComparer<TValue>.Default intrinsic
                    while (true)
                    {
                        // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                        // Test uint in if rather than loop condition to drop range check for following array access
                        if ((uint)i >= (uint)entries.Length)
                        {
                            break;
                        }

                        if (entries[i].hashCode == hashCode && EqualityComparer<int>.Default.Equals(entries[i].key, key))
                        {
                            if (behavior == InsertionBehavior.OverwriteExisting)
                            {
                                entries[i].value = value;
                                _version++;
                                return true;
                            }

                            if (behavior == InsertionBehavior.ThrowOnExisting)
                            {
                                throw new Exception("key");
                            }

                            return false;
                        }

                        i = entries[i].next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            // The chain of entries forms a loop; which means a concurrent update has happened.
                            // Break out of the loop and throw, rather than looping forever.
                            throw new InvalidOperationException("ConcurrentOperationsNotSupported");
                        }
                    }
                }
                else
                {
                    // Object type: Shared Generic, EqualityComparer<TValue>.Default won't devirtualize
                    // https://github.com/dotnet/coreclr/issues/17273
                    // So cache in a local rather than get EqualityComparer per loop iteration
                    EqualityComparer<int> defaultComparer = EqualityComparer<int>.Default;
                    while (true)
                    {
                        // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                        // Test uint in if rather than loop condition to drop range check for following array access
                        if ((uint)i >= (uint)entries.Length)
                        {
                            break;
                        }

                        if (entries[i].hashCode == hashCode && defaultComparer.Equals(entries[i].key, key))
                        {
                            if (behavior == InsertionBehavior.OverwriteExisting)
                            {
                                entries[i].value = value;
                                _version++;
                                return true;
                            }

                            if (behavior == InsertionBehavior.ThrowOnExisting)
                            {
                                throw new Exception("key");
                            }

                            return false;
                        }

                        i = entries[i].next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            // The chain of entries forms a loop; which means a concurrent update has happened.
                            // Break out of the loop and throw, rather than looping forever.
                            throw new InvalidOperationException("ConcurrentOperationsNotSupported");
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    // Should be a while loop https://github.com/dotnet/coreclr/issues/15476
                    // Test uint in if rather than loop condition to drop range check for following array access
                    if ((uint)i >= (uint)entries.Length)
                    {
                        break;
                    }

                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                    {
                        if (behavior == InsertionBehavior.OverwriteExisting)
                        {
                            entries[i].value = value;
                            _version++;
                            return true;
                        }

                        if (behavior == InsertionBehavior.ThrowOnExisting)
                        {
                            throw new Exception("key");
                        }

                        return false;
                    }

                    i = entries[i].next;

                    collisionCount++;
                    if (collisionCount > (uint)entries.Length)
                    {
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        throw new InvalidOperationException("ConcurrentOperationsNotSupported");
                    }
                }
            }

            bool updateFreeList = false;
            int index;
            if (_freeCount > 0)
            {
                index = _freeList;
                updateFreeList = true;
                _freeCount--;
            }
            else
            {
                int count = _count;
                if (count == entries.Length)
                {
                    Resize();
                    bucket = ref GetBucket(hashCode);
                }
                index = count;
                _count = count + 1;
                entries = _entries;
            }

            ref Entry entry = ref entries![index];

            if (updateFreeList)
            {
                Debug.Assert((StartOfFreeList - entries[_freeList].next) >= -1, "shouldn't overflow because `next` cannot underflow");

                _freeList = StartOfFreeList - entries[_freeList].next;
            }
            entry.hashCode = hashCode;
            // Value in _buckets is 1-based
            entry.next = bucket - 1;
            entry.key = key;
            entry.value = value;
            // Value in _buckets is 1-based
            bucket = index + 1;
            _version++;

            // Value types never rehash
            if (default(int) == null && collisionCount > HashCollisionThreshold && comparer is NonRandomizedStringEqualityComparer)
            {
                // If we hit the collision threshold we'll need to switch to the comparer which is using randomized string hashing
                // i.e. EqualityComparer<string>.Default.
                _comparer = null;
                Resize(entries.Length, true);
            }

            return true;
        }
        public const uint HashCollisionThreshold = 100;

        public virtual void OnDeserialization(object? sender)
        {
            HashHelpers.SerializationInfoTable.TryGetValue(this, out SerializationInfo? siInfo);

            if (siInfo == null)
            {
                // We can return immediately if this function is called twice.
                // Note we remove the serialization info from the table at the end of this method.
                return;
            }

            int realVersion = siInfo.GetInt32(VersionName);
            int hashsize = siInfo.GetInt32(HashSizeName);
            _comparer = (IEqualityComparer<int>)siInfo.GetValue(ComparerName, typeof(IEqualityComparer<int>))!; // When serialized if comparer is null, we use the default.

            if (hashsize != 0)
            {
                Initialize(hashsize);

                KeyValuePair<int, TValue>[]? array = (KeyValuePair<int, TValue>[]?)
                    siInfo.GetValue(KeyValuePairsName, typeof(KeyValuePair<int, TValue>[]));

                if (array == null)
                {
                    throw new SerializationException("ExceptionResource.Serialization_MissingKeys");
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Key == null)
                    {
                        throw new SerializationException("ExceptionResource.Serialization_NullKey");
                    }
                    Add(array[i].Key, array[i].Value);
                }
            }
            else
            {
                _buckets = null;
            }

            _version = realVersion;
            HashHelpers.SerializationInfoTable.Remove(this);
        }

        private void Resize()
            => Resize(HashHelpers.ExpandPrime(_count), false);

        private void Resize(int newSize, bool forceNewHashCodes)
        {
            // Value types never rehash
            Debug.Assert(!forceNewHashCodes || default(int) == null);
            Debug.Assert(_entries != null, "_entries should be non-null");
            Debug.Assert(newSize >= _entries.Length);

            Entry[] entries = new Entry[newSize];

            int count = _count;
            Array.Copy(_entries, entries, count);

            if (default(int) == null && forceNewHashCodes)
            {
                for (int i = 0; i < count; i++)
                {
                    if (entries[i].next >= -1)
                    {
                        Debug.Assert(_comparer == null);
                        entries[i].hashCode = (uint)entries[i].key.GetHashCode();
                    }
                }
            }

            // Assign member variables after both arrays allocated to guard against corruption from OOM if second fails
            _buckets = new int[newSize];
#if TARGET_64BIT
            _fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)newSize);
#endif
            for (int i = 0; i < count; i++)
            {
                if (entries[i].next >= -1)
                {
                    ref int bucket = ref GetBucket(entries[i].hashCode);
                    // Value in _buckets is 1-based
                    entries[i].next = bucket - 1;
                    // Value in _buckets is 1-based
                    bucket = i + 1;
                }
            }

            _entries = entries;
        }

        // The overload Remove(int key, out TValue value) is a copy of this method with one additional
        // statement to copy the value for entry being removed into the output parameter.
        // Code has been intentionally duplicated for performance reasons.
        public bool Remove(int key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }

            if (_buckets != null)
            {
                Debug.Assert(_entries != null, "entries should be non-null");
                uint collisionCount = 0;
                uint hashCode = (uint)(_comparer?.GetHashCode(key) ?? key.GetHashCode());
                ref int bucket = ref GetBucket(hashCode);
                Entry[]? entries = _entries;
                int last = -1;
                // Value in buckets is 1-based
                int i = bucket - 1;
                while (i >= 0)
                {
                    ref Entry entry = ref entries[i];

                    if (entry.hashCode == hashCode && (_comparer?.Equals(entry.key, key) ?? EqualityComparer<int>.Default.Equals(entry.key, key)))
                    {
                        if (last < 0)
                        {
                            // Value in buckets is 1-based
                            bucket = entry.next + 1;
                        }
                        else
                        {
                            entries[last].next = entry.next;
                        }

                        Debug.Assert((StartOfFreeList - _freeList) < 0, "shouldn't underflow because max hashtable length is MaxPrimeArrayLength = 0x7FEFFFFD(2146435069) _freelist underflow threshold 2147483646");

                        entry.next = StartOfFreeList - _freeList;

                        if (RuntimeHelpers.IsReferenceOrContainsReferences<int>())
                        {
                            entry.key = default!;
                        }
                        if (RuntimeHelpers.IsReferenceOrContainsReferences<TValue>())
                        {
                            entry.value = default!;
                        }
                        _freeList = i;
                        _freeCount++;
                        return true;
                    }

                    last = i;
                    i = entry.next;

                    collisionCount++;
                    if (collisionCount > (uint)entries.Length)
                    {
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        throw new InvalidOperationException("ConcurrentOperationsNotSupported");
                    }
                }
            }
            return false;
        }

        // This overload is a copy of the overload Remove(int key) with one additional
        // statement to copy the value for entry being removed into the output parameter.
        // Code has been intentionally duplicated for performance reasons.
        public bool Remove(int key, [MaybeNullWhen(false)] out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }

            if (_buckets != null)
            {
                Debug.Assert(_entries != null, "entries should be non-null");
                uint collisionCount = 0;
                uint hashCode = (uint)(_comparer?.GetHashCode(key) ?? key.GetHashCode());
                ref int bucket = ref GetBucket(hashCode);
                Entry[]? entries = _entries;
                int last = -1;
                // Value in buckets is 1-based
                int i = bucket - 1;
                while (i >= 0)
                {
                    ref Entry entry = ref entries[i];

                    if (entry.hashCode == hashCode && (_comparer?.Equals(entry.key, key) ?? EqualityComparer<int>.Default.Equals(entry.key, key)))
                    {
                        if (last < 0)
                        {
                            // Value in buckets is 1-based
                            bucket = entry.next + 1;
                        }
                        else
                        {
                            entries[last].next = entry.next;
                        }

                        value = entry.value;

                        Debug.Assert((StartOfFreeList - _freeList) < 0, "shouldn't underflow because max hashtable length is MaxPrimeArrayLength = 0x7FEFFFFD(2146435069) _freelist underflow threshold 2147483646");

                        entry.next = StartOfFreeList - _freeList;

                        if (RuntimeHelpers.IsReferenceOrContainsReferences<int>())
                        {
                            entry.key = default!;
                        }
                        if (RuntimeHelpers.IsReferenceOrContainsReferences<TValue>())
                        {
                            entry.value = default!;
                        }
                        _freeList = i;
                        _freeCount++;
                        return true;
                    }

                    last = i;
                    i = entry.next;

                    collisionCount++;
                    if (collisionCount > (uint)entries.Length)
                    {
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        throw new InvalidOperationException("ConcurrentOperationsNotSupported");
                    }
                }
            }
            value = default!;
            return false;
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out TValue value)
        {
            ref TValue valRef = ref FindValue(key);
            if (!Unsafe.IsNullRef(ref valRef))
            {
                value = valRef;
                return true;
            }
            value = default!;
            return false;
        }

        public bool TryAdd(int key, TValue value)
            => TryInsert(key, value, InsertionBehavior.None);

        bool ICollection<KeyValuePair<int, TValue>>.IsReadOnly => false;

        void ICollection<KeyValuePair<int, TValue>>.CopyTo(KeyValuePair<int, TValue>[] array, int index)
            => CopyTo(array, index);

        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("ExceptionArgument.array");
            if (array.Rank != 1)
                throw new ArgumentException("ExceptionResource.Arg_RankMultiDimNotSupported");
            if (array.GetLowerBound(0) != 0)
                throw new ArgumentException("ExceptionResource.Arg_NonZeroLowerBound");
            if ((uint)index > (uint)array.Length)
                throw new ArgumentOutOfRangeException("NeedNonNegNumException");
            if (array.Length - index < Count)
                throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");

            if (array is KeyValuePair<int, TValue>[] pairs)
            {
                CopyTo(pairs, index);
            }
            else if (array is DictionaryEntry[] dictEntryArray)
            {
                Entry[]? entries = _entries;
                for (int i = 0; i < _count; i++)
                {
                    if (entries![i].next >= -1)
                    {
                        dictEntryArray[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
                    }
                }
            }
            else
            {
                object[]? objects = array as object[];
                if (objects == null)
                {
                    throw new ArgumentException("Argument_InvalidArrayType");
                }

                try
                {
                    int count = _count;
                    Entry[]? entries = _entries;
                    for (int i = 0; i < count; i++)
                    {
                        if (entries![i].next >= -1)
                        {
                            objects[index++] = new KeyValuePair<int, TValue>(entries[i].key, entries[i].value);
                        }
                    }
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("Argument_InvalidArrayType");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this, Enumerator.KeyValuePair);

        /// <summary>
        /// Ensures that the dictionary can hold up to 'capacity' entries without any further expansion of its backing storage
        /// </summary>
        public int EnsureCapacity(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");
            int currentCapacity = _entries == null ? 0 : _entries.Length;
            if (currentCapacity >= capacity)
                return currentCapacity;
            _version++;
            if (_buckets == null)
                return Initialize(capacity);

            int newSize = HashHelpers.GetPrime(capacity);
            Resize(newSize, forceNewHashCodes: false);
            return newSize;
        }

        /// <summary>
        /// Sets the capacity of this dictionary to what it would be if it had been originally initialized with all its entries
        ///
        /// This method can be used to minimize the memory overhead
        /// once it is known that no new elements will be added.
        ///
        /// To allocate minimum size storage array, execute the following statements:
        ///
        /// dictionary.Clear();
        /// dictionary.TrimExcess();
        /// </summary>
        public void TrimExcess()
            => TrimExcess(Count);

        /// <summary>
        /// Sets the capacity of this dictionary to hold up 'capacity' entries without any further expansion of its backing storage
        ///
        /// This method can be used to minimize the memory overhead
        /// once it is known that no new elements will be added.
        /// </summary>
        public void TrimExcess(int capacity)
        {
            if (capacity < Count)
                throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");

            int newSize = HashHelpers.GetPrime(capacity);
            Entry[]? oldEntries = _entries;
            int currentCapacity = oldEntries == null ? 0 : oldEntries.Length;
            if (newSize >= currentCapacity)
                return;

            int oldCount = _count;
            _version++;
            Initialize(newSize);
            Entry[]? entries = _entries;
            int count = 0;
            for (int i = 0; i < oldCount; i++)
            {
                uint hashCode = oldEntries![i].hashCode; // At this point, we know we have entries.
                if (oldEntries[i].next >= -1)
                {
                    ref Entry entry = ref entries![count];
                    entry = oldEntries[i];
                    ref int bucket = ref GetBucket(hashCode);
                    // Value in _buckets is 1-based
                    entry.next = bucket - 1;
                    // Value in _buckets is 1-based
                    bucket = count + 1;
                    count++;
                }
            }
            _count = count;
            _freeCount = 0;
        }

        bool ICollection.IsSynchronized => false;

        object ICollection.SyncRoot => this;

        bool IDictionary.IsFixedSize => false;

        bool IDictionary.IsReadOnly => false;

        ICollection IDictionary.Keys => (ICollection)Keys;

        ICollection IDictionary.Values => (ICollection)Values;

        object? IDictionary.this[object key]
        {
            get
            {
                if (IsCompatibleKey(key))
                {
                    ref TValue value = ref FindValue((int)key);
                    if (!Unsafe.IsNullRef(ref value))
                    {
                        return value;
                    }
                }
                return null;
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("ExceptionArgument.key");
                }
             //   ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);

                try
                {
                    int tempKey = (int)key;
                    try
                    {
                        this[tempKey] = (TValue)value!;
                    }
                    catch (InvalidCastException)
                    {
                        throw new Exception("value");
                    }
                }
                catch (InvalidCastException)
                {
                    throw new Exception("key");
                }
            }
        }

        private static bool IsCompatibleKey(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }
            return key is int;
        }

        void IDictionary.Add(object key, object? value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("ExceptionArgument.key");
            }
            //ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);

            try
            {
                int tempKey = (int)key;

                try
                {
                    Add(tempKey, (TValue)value!);
                }
                catch (InvalidCastException)
                {
                    throw new Exception("value");
                }
            }
            catch (InvalidCastException)
            {
                throw new Exception("key");
            }
        }

        bool IDictionary.Contains(object key)
        {
            if (IsCompatibleKey(key))
            {
                return ContainsKey((int)key);
            }

            return false;
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
            => new Enumerator(this, Enumerator.DictEntry);

        void IDictionary.Remove(object key)
        {
            if (IsCompatibleKey(key))
            {
                Remove((int)key);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref int GetBucket(uint hashCode)
        {
            int[] buckets = _buckets!;
#if TARGET_64BIT
            return ref buckets[HashHelpers.FastMod(hashCode, (uint)buckets.Length, _fastModMultiplier)];
#else
            return ref buckets[hashCode % (uint)buckets.Length];
#endif
        }

        public struct Enumerator : IEnumerator<KeyValuePair<int, TValue>>,
            IDictionaryEnumerator
        {
            private readonly DictionaryIntTest<TValue> _dictionary;
            private readonly int _version;
            private int _index;
            private KeyValuePair<int, TValue> _current;
            private readonly int _getEnumeratorRetType;  // What should Enumerator.Current return?

            internal const int DictEntry = 1;
            internal const int KeyValuePair = 2;

            internal Enumerator(DictionaryIntTest<TValue> dictionary, int getEnumeratorRetType)
            {
                _dictionary = dictionary;
                _version = dictionary._version;
                _index = 0;
                _getEnumeratorRetType = getEnumeratorRetType;
                _current = default;
            }

            public bool MoveNext()
            {
                if (_version != _dictionary._version)
                {
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                }

                // Use unsigned comparison since we set index to dictionary.count+1 when the enumeration ends.
                // dictionary.count+1 could be negative if dictionary.count is int.MaxValue
                while ((uint)_index < (uint)_dictionary._count)
                {
                    ref Entry entry = ref _dictionary._entries![_index++];

                    if (entry.next >= -1)
                    {
                        _current = new KeyValuePair<int, TValue>(entry.key, entry.value);
                        return true;
                    }
                }

                _index = _dictionary._count + 1;
                _current = default;
                return false;
            }

            public KeyValuePair<int, TValue> Current => _current;

            public void Dispose()
            {
            }

            object? IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || (_index == _dictionary._count + 1))
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    }

                    if (_getEnumeratorRetType == DictEntry)
                    {
                        return new DictionaryEntry(_current.Key, _current.Value);
                    }
                    else
                    {
                        return new KeyValuePair<int, TValue>(_current.Key, _current.Value);
                    }
                }
            }

            void IEnumerator.Reset()
            {
                if (_version != _dictionary._version)
                {
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                }

                _index = 0;
                _current = default;
            }

            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
                    if (_index == 0 || (_index == _dictionary._count + 1))
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    }

                    return new DictionaryEntry(_current.Key, _current.Value);
                }
            }

            object IDictionaryEnumerator.Key
            {
                get
                {
                    if (_index == 0 || (_index == _dictionary._count + 1))
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    }

                    return _current.Key;
                }
            }

            object? IDictionaryEnumerator.Value
            {
                get
                {
                    if (_index == 0 || (_index == _dictionary._count + 1))
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    }

                    return _current.Value;
                }
            }
        }

       [DebuggerDisplay("Count = {Count}")]
        public sealed class KeyCollection : ICollection<int>, ICollection, IReadOnlyCollection<int>
        {
            private readonly DictionaryIntTest<TValue> _dictionary;

            public KeyCollection(DictionaryIntTest<TValue> dictionary)
            {
                if (dictionary == null)
                {
                    throw new ArgumentNullException("ExceptionArgument.dictionary");
                }
                _dictionary = dictionary;
            }

            public Enumerator GetEnumerator()
                => new Enumerator(_dictionary);

            public void CopyTo(int[] array, int index)
            {
                if (array == null)
                {
                    throw new ArgumentNullException("ExceptionArgument.array");
                }

                if (index < 0 || index > array.Length)
                {
                    throw new ArgumentOutOfRangeException("NeedNonNegNumException");
                }

                if (array.Length - index < _dictionary.Count)
                {
                    throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
                }

                int count = _dictionary._count;
                Entry[]? entries = _dictionary._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries![i].next >= -1) array[index++] = entries[i].key;
                }
            }

            public int Count => _dictionary.Count;

            bool ICollection<int>.IsReadOnly => true;

            void ICollection<int>.Add(int item)
                => throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");

            void ICollection<int>.Clear()
                => throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");

            bool ICollection<int>.Contains(int item)
                => _dictionary.ContainsKey(item);

            bool ICollection<int>.Remove(int item)
            {
                throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");
                return false;
            }

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
                => new Enumerator(_dictionary);

            IEnumerator IEnumerable.GetEnumerator()
                => new Enumerator(_dictionary);

            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("ExceptionArgument.array");
                if (array.Rank != 1)
                    throw new ArgumentException("ExceptionResource.Arg_RankMultiDimNotSupported");
                if (array.GetLowerBound(0) != 0)
                    throw new ArgumentException("ExceptionResource.Arg_NonZeroLowerBound");
                if ((uint)index > (uint)array.Length)
                    throw new ArgumentOutOfRangeException("NeedNonNegNumException");
                if (array.Length - index < _dictionary.Count)
                    throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");

                if (array is int[] keys)
                {
                    CopyTo(keys, index);
                }
                else
                {
                    object[]? objects = array as object[];
                    if (objects == null)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }

                    int count = _dictionary._count;
                    Entry[]? entries = _dictionary._entries;
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (entries![i].next >= -1) objects[index++] = entries[i].key;
                        }
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }
                }
            }

            bool ICollection.IsSynchronized => false;

            object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

            public struct Enumerator : IEnumerator<int>, IEnumerator
            {
                private readonly DictionaryIntTest<TValue> _dictionary;
                private int _index;
                private readonly int _version;
                [AllowNull, MaybeNull] private int _currentKey;

                internal Enumerator(DictionaryIntTest<TValue> dictionary)
                {
                    _dictionary = dictionary;
                    _version = dictionary._version;
                    _index = 0;
                    _currentKey = default;
                }

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    if (_version != _dictionary._version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }

                    while ((uint)_index < (uint)_dictionary._count)
                    {
                        ref Entry entry = ref _dictionary._entries![_index++];

                        if (entry.next >= -1)
                        {
                            _currentKey = entry.key;
                            return true;
                        }
                    }

                    _index = _dictionary._count + 1;
                    _currentKey = default;
                    return false;
                }

                public int Current => _currentKey!;

                object? IEnumerator.Current
                {
                    get
                    {
                        if (_index == 0 || (_index == _dictionary._count + 1))
                        {
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        }

                        return _currentKey;
                    }
                }

                void IEnumerator.Reset()
                {
                    if (_version != _dictionary._version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }

                    _index = 0;
                    _currentKey = default;
                }
            }
        }

        [DebuggerDisplay("Count = {Count}")]
        public sealed class ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue>
        {
            private readonly DictionaryIntTest<TValue> _dictionary;

            public ValueCollection(DictionaryIntTest<TValue> dictionary)
            {
                if (dictionary == null)
                {
                    throw new ArgumentNullException("ExceptionArgument.dictionary");
                }
                _dictionary = dictionary;
            }

            public Enumerator GetEnumerator()
                => new Enumerator(_dictionary);

            public void CopyTo(TValue[] array, int index)
            {
                if (array == null)
                {
                    throw new ArgumentNullException("ExceptionArgument.array");
                }

                if ((uint)index > array.Length)
                {
                    throw new ArgumentOutOfRangeException("NeedNonNegNumException");
                }

                if (array.Length - index < _dictionary.Count)
                {
                    throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
                }

                int count = _dictionary._count;
                Entry[]? entries = _dictionary._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries![i].next >= -1) array[index++] = entries[i].value;
                }
            }

            public int Count => _dictionary.Count;

            bool ICollection<TValue>.IsReadOnly => true;

            void ICollection<TValue>.Add(TValue item)
                => throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");

            bool ICollection<TValue>.Remove(TValue item)
            {
                throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");
                return false;
            }

            void ICollection<TValue>.Clear()
                => throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");

            bool ICollection<TValue>.Contains(TValue item)
                => _dictionary.ContainsValue(item);

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
                => new Enumerator(_dictionary);

            IEnumerator IEnumerable.GetEnumerator()
                => new Enumerator(_dictionary);

            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("ExceptionArgument.array");
                if (array.Rank != 1)
                    throw new ArgumentException("ExceptionResource.Arg_RankMultiDimNotSupported");
                if (array.GetLowerBound(0) != 0)
                    throw new ArgumentException("ExceptionResource.Arg_NonZeroLowerBound");
                if ((uint)index > (uint)array.Length)
                    throw new ArgumentOutOfRangeException("NeedNonNegNumException");
                if (array.Length - index < _dictionary.Count)
                    throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");

                if (array is TValue[] values)
                {
                    CopyTo(values, index);
                }
                else
                {
                    object[]? objects = array as object[];
                    if (objects == null)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }

                    int count = _dictionary._count;
                    Entry[]? entries = _dictionary._entries;
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (entries![i].next >= -1) objects[index++] = entries[i].value!;
                        }
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }
                }
            }

            bool ICollection.IsSynchronized => false;

            object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

            public struct Enumerator : IEnumerator<TValue>, IEnumerator
            {
                private readonly DictionaryIntTest<TValue> _dictionary;
                private int _index;
                private readonly int _version;
                [AllowNull, MaybeNull] private TValue _currentValue;

                internal Enumerator(DictionaryIntTest<TValue> dictionary)
                {
                    _dictionary = dictionary;
                    _version = dictionary._version;
                    _index = 0;
                    _currentValue = default;
                }

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    if (_version != _dictionary._version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }

                    while ((uint)_index < (uint)_dictionary._count)
                    {
                        ref Entry entry = ref _dictionary._entries![_index++];

                        if (entry.next >= -1)
                        {
                            _currentValue = entry.value;
                            return true;
                        }
                    }
                    _index = _dictionary._count + 1;
                    _currentValue = default;
                    return false;
                }

                public TValue Current => _currentValue!;

                object? IEnumerator.Current
                {
                    get
                    {
                        if (_index == 0 || (_index == _dictionary._count + 1))
                        {
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        }

                        return _currentValue;
                    }
                }

                void IEnumerator.Reset()
                {
                    if (_version != _dictionary._version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }
                    _index = 0;
                    _currentValue = default;
                }
            }
        }
    }
}
