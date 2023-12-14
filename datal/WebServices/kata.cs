namespace WebServices;

using System;
using System.Linq;

public class Kata
{
  public static string TitleCase(string title, string minorWords="")
  {
    if (string.IsNullOrEmpty(title)) 
      return "";

    Char[] splitters = new Char[] {' '};
    StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    var rawCollection =  title.Split(splitters, splitOptions).Select(x => x.ToLower()).ToList();
    var skipCollection = minorWords?.Split(splitters, splitOptions).Select(x => x.ToLower()).ToList() ?? new string[] {""}.ToList();

    if (rawCollection.Count == 0) 
      return "";

    var parsedCollection = rawCollection
                            .Select((x, i) => i != 0 && skipCollection.Contains(x) ? x : String.Concat(x[..1].ToUpper(), x[1..].ToLower()))
                            .ToList();
    return String.Join(" ", parsedCollection);
  }
}