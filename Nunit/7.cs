/*7. Performance Testing Using Timeout
Problem:
Create a method LongRunningTask() that sleeps for 3 seconds before returning a result.
Use NUnit [Timeout(2000)] or MSTest [Timeout(2000)] to fail the test if the method takes more than 2 seconds.
*/

using System;
using System.Threading;

public class TaskProcessor
{
    public string LongRunningTask()
    {
        Thread.Sleep(3000); //simulating a long-running task (3 seconds)
        return "Task Completed";
    }
}
//Test Cases
using NUnit.Framework;

[TestFixture]
public class TaskProcessorTests
{
    private TaskProcessor _taskProcessor;

    [SetUp]
    public void Setup()
    {
        _taskProcessor = new TaskProcessor();
    }

    [Test, Timeout(2000)] // Test fails if it takes more than 2 seconds
    public void LongRunningTask_ShouldTimeout()
    {
        _taskProcessor.LongRunningTask();
    }
    public class TaskProcessorTests
    {
        private TaskProcessor _taskProcessor;

        [TestInitialize]
        public void Setup()
        {
            _taskProcessor = new TaskProcessor();
        }

        [TestMethod]
        [Timeout(2000)] // Test fails if it takes more than 2 seconds
        public void LongRunningTask_ShouldTimeout()
        {
            _taskProcessor.LongRunningTask();
        }
    }

