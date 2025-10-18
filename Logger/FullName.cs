using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
/// <summary>
/// The First Middle and Last variables are defined as 'refrence' types.
/// 
/// The record is immutable since it consists solely of immutable string fields.
/// </summary>
public record class FullName
{
    public string First { get; }
    public string? Middle { get; }
    public string Last { get; }

    public FullName(string firstName, string? middleName, string lastName)
    {
        First = firstName ?? throw new ArgumentNullException(nameof(firstName));
        Last = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Middle = string.IsNullOrWhiteSpace(middleName) ? null : middleName;
    }
    public override string ToString()
    {
        return $"{First} {Middle} {Last}";
    }
}
