using System;
using System.IO;
using System.Collections.Generic;
public static class DatabaseIO {
    public static void SaveToDatabase<T>(List<T> input, string path) {
        using (StreamWriter file = new StreamWriter(path)) {
            foreach (T item in input) {
                if (item != null) file.WriteLine(item.ToString());
            }
        }
    }
    public static List<Entry> LoadFromEntryDatabase(string path) {
        List<Entry> result = new List<Entry>();
        foreach(string line in ReadFile(path)) {
            result.Add(GenerateEntryInstance(line.Split(',')));
        }
        return result;
    }
    public static List<Type> LoadFromTypeDatabase(string path) {
        List<Type> result = new List<Type>();
        foreach(string line in ReadFile(path)) {
            result.Add(GenerateTypeInstance(line.Split(',')));
        }
        return result;
    }
    private static double? ConvertToNullableDouble(string input) {
        if (input == "") {
            return null;
        } else {
            return Convert.ToDouble(input,System.Globalization.CultureInfo.InvariantCulture);
        }
    }
    private static int? ConvertToNullableInt(string input) {
        if (input == "") {
            return null;
        } else {
            return Convert.ToInt32(input);
        }
    }
    private static List<string> ReadFile(string path) {
        List<string> result = new List<string>();
        using (StreamReader file = new StreamReader(path)) {
            string? line;
            while ((line = file.ReadLine()) != null) {
                result.Add(line);
            }
        }
        return result;    
    }
    private static Entry GenerateEntryInstance(string[] input) {
        switch(input.Length) {
            case 6: return new Entry(input[0],input[1],DateOnly.Parse(input[2]),DateOnly.Parse(input[3]),
                                    Convert.ToUInt32(input[4]),ConvertToNullableDouble(input[5]));
            case 8: return new AdvancedEntry(input[0],input[1],DateOnly.Parse(input[2]),DateOnly.Parse(input[3]),Convert.ToUInt32(input[4]),
                                            ConvertToNullableDouble(input[5]),Convert.ToBoolean(input[6]),ConvertToNullableDouble(input[7]));
            default: throw new FormatException();
        }
        
    }
    private static Type GenerateTypeInstance(string[] input) {
        if (input.Length == 6) {
            return new Type(input[0],input[1],ConvertToNullableDouble(input[2]),ConvertToNullableInt(input[3]),input[4].Split(';'),Convert.ToUInt32(input[5]));
        } else {
            throw new FormatException();
        }
    }
 }