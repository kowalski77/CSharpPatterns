// See https://aka.ms/new-console-template for more information
using FunctionalProgramming.Caches;

Console.WriteLine("Hello, World!");

var currencies = new string[] { "eu", "us", "mk", "do", "re", "mi", "fa", "so", "la", "si", "eu" };

var cache = HashSetCache.Create(currencies, currencies.Length);

Console.ReadKey();  