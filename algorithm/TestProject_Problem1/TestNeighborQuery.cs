using ClassLibraryProb1;

namespace TestProject_Problem1;

public class TestNeighborQuery
{
    private int[][] testData;
 
    [SetUp]
    public void Setup()
    {
        testData = new int[4][];
        int i = 0;
        testData[i++] = new int[]{3, 2, 4, 2, 3, 2, 3} ;
        testData[i++] = new int[]{3, 2, 4, 2, 3, 2, 3} ;
        testData[i++] = new int[]{3, 2, 4, 2, 3, 2, 3} ;
        testData[i++] = new int[]{3, 2, 4, 2, 3, 2, 3} ;
    }

    [Test]
    public void Test_NeighborInTheMiddle()
    {
        int actual, expected, houseNumber;
            
        houseNumber = 11;
        actual = NeighborQuery.getNeiboringHouseCount(testData, houseNumber);
        expected = 25;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Test_BorderNeighbors()
    {
        int actual, expected, houseNumber;
        
        // top row
        houseNumber = 4;
        actual = NeighborQuery.getNeiboringHouseCount(testData, houseNumber);
        expected = 16;
        Assert.AreEqual(expected, actual);
            
        
        // bottom row
        houseNumber = 22;
        actual = NeighborQuery.getNeiboringHouseCount(testData, houseNumber);
        expected = 7;
        Assert.AreEqual(expected, actual);
        
    }
    
    [Test]
    public void TestStartNeighbor()
    {
        int actual, expected, houseNumber;
        
        houseNumber = 1;
        actual = NeighborQuery.getNeiboringHouseCount(testData, houseNumber);
        expected = 7;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void TestEndNeighbor()
    {
        int actual, expected, houseNumber;
        
        houseNumber = 28;
        actual = NeighborQuery.getNeiboringHouseCount(testData, houseNumber);
        expected = 7;
        Assert.AreEqual(expected, actual);
    }
}