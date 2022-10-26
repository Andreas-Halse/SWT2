using ClassLibrary;
using NUnit.Framework;

namespace SWT2_Test;

public class TestDoor
{
    private Door _uut;
    private DoorEventArgs _open;
    
    [SetUp]
    public void Setup()
    {
        _open = null;

        _uut = new Door();

        // Set up an event listener to check the event occurrence and event data
        _uut.DoorStateChange +=
            (o, args) =>
            {
                _open = args;
            };
    }
    
    [Test]
    public void DoorLockedTest()
    {
        IDoor uut = new Door();
        uut.DoorLock();
        Assert.That(uut.locked == true);
    }
    
    [Test]

    public void DoorUnlockedTest()
    {
        IDoor uut = new Door();
        uut.DoorUnlock();
        Assert.That(uut.locked == false);
    }
    
    [Test]

    public void DoorOpenedTest()
    {
        IDoor uut = new Door();
        uut.DoorOpened();
        Assert.That(uut._open == true);
    }
    
    [Test]

    public void DoorClosedTest()
    {
        IDoor uut = new Door();
        uut.DoorClosed();
        Assert.That(uut._open == false);
    }
    
    [Test]
    
    public void DoorOpenedEventTest() //Event test opened
    {
        _uut.DoorOpened();
        Assert.That(_open.open, Is.True);
    }

    [Test]

    public void DoorClosedEventTest() //Event test closed
    {
        _uut.DoorClosed();
        Assert.That(_open.open, Is.False);
    }
}