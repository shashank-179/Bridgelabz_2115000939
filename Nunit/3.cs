/*3. Testing List Operations
Problem:
Create a ListManager class that has the following methods:
AddElement(List<int> list, int element): Adds an element to a list.
RemoveElement(List<int> list, int element): Removes an element from a list.
GetSize(List<int> list): Returns the size of the list.
Write NUnit or MSTest tests to verify that:
✅ Elements are correctly added.
✅ Elements are correctly removed.
✅ The size of the list is updated correctly.
*/

using System;
using System.Collections.Generic;

public class ListManager
{
    // Adds an element to the list
    public void AddElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        list.Add(element);
    }

    // Removes an element from the list (if it exists)
    public bool RemoveElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Remove(element);
    }

    // Returns the size of the list
    public int GetSize(List<int> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Count;
    }
}
//Test Cases
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ListManagerTests
{
    private ListManager _listManager;
    private List<int> _list;

    [SetUp]
    public void Setup()
    {
        _listManager = new ListManager();
        _list = new List<int>();
    }

    [Test]
    public void AddElement_AddsElementToList()
    {
        _listManager.AddElement(_list, 10);
        Assert.Contains(10, _list);
    }

    [Test]
    public void RemoveElement_RemovesExistingElement()
    {
        _listManager.AddElement(_list, 20);
        bool removed = _listManager.RemoveElement(_list, 20);
        Assert.IsTrue(removed);
        Assert.IsFalse(_list.Contains(20));
    }

    [Test]
    public void RemoveElement_ReturnsFalseIfElementNotFound()
    {
        bool removed = _listManager.RemoveElement(_list, 30);
        Assert.IsFalse(removed);
    }

    [Test]
    public void GetSize_ReturnsCorrectListSize()
    {
        _listManager.AddElement(_list, 5);
        _listManager.AddElement(_list, 15);
        Assert.AreEqual(2, _listManager.GetSize(_list));
    }

    [Test]
    public void Methods_ThrowExceptionForNullList()
    {
        Assert.Throws<ArgumentNullException>(() => _listManager.AddElement(null, 5));
        Assert.Throws<ArgumentNullException>(() => _listManager.RemoveElement(null, 5));
        Assert.Throws<ArgumentNullException>(() => _listManager.GetSize(null));
    }
}

