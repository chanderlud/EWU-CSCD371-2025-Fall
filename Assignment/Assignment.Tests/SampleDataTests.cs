using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    // A derived class to override CsvRows for testing purposes
    private class SampleDataForTest : SampleData
    {
        private readonly IEnumerable<string> _rows;

        public SampleDataForTest(IEnumerable<string> rows)
        {
            _rows = rows;
        }

        public override IEnumerable<string> CsvRows => _rows;
    }

    [TestMethod]
    public void CsvRows_LoadAllRows_SkipHeader()
    {
        // Arrange & Act
        var data = new SampleData();
        var rows = data.CsvRows.ToList();

        // Assert
        Assert.IsNotEmpty(rows);
        Assert.IsFalse(rows.Any(r => r.Contains("FirstName")));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsCorrectStates()
    {
        // Arrange
        var data = new SampleDataForTest(new List<string>
            {
                "1,Alice,Smith,alice@email.com,123 Main St,Seattle,WA,98101",
                "2,Bob,Lee,bob@email.com,456 Elm St,San Francisco,CA,94102",
                "3,Charlie,Brown,charlie@email.com,789 Oak St,Los Angeles,CA,90001",
                "4,Dave,Clark,dave@email.com,111 Pine St,Portland,OR,97201"
            });

        // Act
        var result = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        // Assert
        CollectionAssert.AreEqual(new List<string> { "CA", "OR", "WA" }, result);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted_LINQTest()
    {
        // Arrange
        var data = new SampleDataForTest(new List<string>
            {
                "1,Alice,Smith,alice@email.com,123 Main St,Seattle,WA,98101",
                "2,Bob,Lee,bob@email.com,456 Elm St,San Francisco,CA,94102",
                "3,Charlie,Brown,charlie@email.com,789 Oak St,Los Angeles,CA,90001",
                "4,Dave,Clark,dave@email.com,111 Pine St,Portland,OR,97201"
            });

        // Act
        var result = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        // Assert
        var sorted = result.OrderBy(s => s).ToList();
        CollectionAssert.AreEqual(sorted, result);
    }
}
