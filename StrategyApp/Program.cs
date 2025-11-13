using System;

namespace StrategyApp
{
    /// <summary>
    /// Strategy Design Pattern Example
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var handler = new StrategyHandler();

            // Sorting Example
            handler.SetSorter(new Sorter(new QuickSort()));
            handler.Sort([5, 3, 8, 1]);

            // Compression Example
            handler.SetCompressor(new Compressor(new ZipCompression()));
            handler.Compress("file.txt");

            // Encryption Example
            handler.SetEncryptor(new Encryptor(new AesEncryption()));
            handler.Encrypt("Sensitive Data");
        }
    }

    // ==============================
    // STRATEGY INTERFACES
    // ==============================

    // Sorting
    public abstract class SortingStrategy
    {
        public abstract void Sort(int[] array);
    }

    public class BubbleSort : SortingStrategy
    {
        public override void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Bubble Sort");
        }
    }

    public class QuickSort : SortingStrategy
    {
        public override void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Quick Sort");
        }
    }

    public class MergeSort : SortingStrategy
    {
        public override void Sort(int[] array)
        {
            Console.WriteLine("Sorting using Merge Sort");
        }
    }

    // Compression
    public abstract class CompressionStrategy
    {
        public abstract void Compress(string filePath);
    }

    public class ZipCompression : CompressionStrategy
    {
        public override void Compress(string filePath)
        {
            Console.WriteLine("Compressing using ZIP");
        }
    }

    public class RarCompression : CompressionStrategy
    {
        public override void Compress(string filePath)
        {
            Console.WriteLine("Compressing using RAR");
        }
    }

    public class GZipCompression : CompressionStrategy
    {
        public override void Compress(string filePath)
        {
            Console.WriteLine("Compressing using GZIP");
        }
    }

    // Encryption
    public abstract class EncryptionStrategy
    {
        public abstract void Encrypt(string data);
    }

    public class AesEncryption : EncryptionStrategy
    {
        public override void Encrypt(string data)
        {
            Console.WriteLine("Encrypting using AES");
        }
    }

    public class DesEncryption : EncryptionStrategy
    {
        public override void Encrypt(string data)
        {
            Console.WriteLine("Encrypting using DES");
        }
    }

    public class RsaEncryption : EncryptionStrategy
    {
        public override void Encrypt(string data)
        {
            Console.WriteLine("Encrypting using RSA");
        }
    }

    // ==============================
    // CONTEXT CLASSES
    // ==============================

    public class Sorter(SortingStrategy strategy)
    {
        private SortingStrategy _strategy = strategy;

        public void SetStrategy(SortingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Sort(int[] array)
        {
            _strategy.Sort(array);
        }
    }

    public class Compressor(CompressionStrategy strategy)
    {
        private CompressionStrategy _strategy = strategy;

        public void SetStrategy(CompressionStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Compress(string filePath)
        {
            _strategy.Compress(filePath);
        }
    }

    public class Encryptor(EncryptionStrategy strategy)
    {
        private EncryptionStrategy _strategy = strategy;

        public void SetStrategy(EncryptionStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Encrypt(string data)
        {
            _strategy.Encrypt(data);
        }
    }

    // ==============================
    // UNIFIED HANDLER
    // ==============================

    public class StrategyHandler
    {
        private Sorter? sorter;
        private Compressor? compressor;
        private Encryptor? encryptor;

        public StrategyHandler()
        {
            sorter = null;
            compressor = null;
            encryptor = null;
        }

        public void SetSorter(Sorter sorter)
        {
            this.sorter = sorter;
        }

        public void SetCompressor(Compressor compressor)
        {
            this.compressor = compressor;
        }

        public void SetEncryptor(Encryptor encryptor)
        {
            this.encryptor = encryptor;
        }

        public void Sort(int[] array)
        {
            if (sorter == null)
                throw new InvalidOperationException("No sorting strategy set.");
            sorter.Sort(array);
        }

        public void Compress(string filePath)
        {
            if (compressor == null)
                throw new InvalidOperationException("No compression strategy set.");
            compressor.Compress(filePath);
        }

        public void Encrypt(string data)
        {
            if (encryptor == null)
                throw new InvalidOperationException("No encryption strategy set.");
            encryptor.Encrypt(data);
        }
    }
}
