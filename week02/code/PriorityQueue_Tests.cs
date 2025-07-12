using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Green (1), Red (3), Yellow (2) 
    // The Dequeue function shall remove the item with the highest priority and return its value.
    // Expected Result: Red, Yellow, Green (in this order, from highest to lowest priority).
    // Defect(s) Found: The queue was implemented using a List but incorrectly handled priorities.
    //                  Also, the queue field was private and not accessible for validation.
    public void TestPriorityQueue_1()
    {
        var green = new PriorityItem("Green", 1);
        var red = new PriorityItem("Red", 3);
        var yellow = new PriorityItem("Yellow", 2);

        PriorityItem[] expectedResult = [red, yellow, green];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(red.Value, red.Priority);
        priorityQueue.Enqueue(yellow.Value, yellow.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var item = priorityQueue.Dequeue();

            Assert.AreEqual(expectedResult[i].Value, item);
            Console.WriteLine(item);
            i++;
        }
        
        
    }

    [TestMethod]
    // Scenario: Add multiple people, including two with the same highest priority (Red, Red).
    // If there are multiple items with the same highest priority, the one added first should be dequeued first.
    // Expected Result: Red, Red, Yellow, Yellow, Yellow, Green (based on priority and insertion order).
    // Defect(s) Found: The dequeue logic failed to preserve insertion order when priorities were equal.
    public void TestPriorityQueue_2()
    {
        var green = new PriorityItem("Green", 1);
        var red = new PriorityItem("Red", 3);
        var yellow = new PriorityItem("Yellow", 2);

        PriorityItem[] expectedResult = [red, red, yellow , yellow , yellow, green];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(red.Value, red.Priority);
        priorityQueue.Enqueue(yellow.Value, yellow.Priority);
        priorityQueue.Enqueue(red.Value, red.Priority);
        priorityQueue.Enqueue(yellow.Value, yellow.Priority);
        priorityQueue.Enqueue(yellow.Value, yellow.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var item = priorityQueue.Dequeue();

            Assert.AreEqual(expectedResult[i].Value, item);
            Console.WriteLine(item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: Previously, no exception was thrown on empty queue, causing unexpected behavior.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_3()
    {
        var green = new PriorityItem("Green", 1);
        var red = new PriorityItem("Red", 3);
        var yellow = new PriorityItem("Yellow", 2);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();

    }

}