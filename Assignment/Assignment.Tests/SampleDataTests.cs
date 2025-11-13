using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_LoadAllRows_SkipHeader()
    {
        var data = new SampleData();
        var rows = data.CsvRows.ToList();

        Assert.IsNotEmpty(rows);
        Assert.IsFalse(rows.Any(r => r.Contains("FirstName")));
    }
}
