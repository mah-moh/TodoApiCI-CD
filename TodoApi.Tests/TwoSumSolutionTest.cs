using Xunit;

namespace TodoApi;
public class TwoSumSolutionTests
{
    private readonly TwoSumSolution _twoSumSolution = new();

    [Fact]
    public void NormalCase_FindsPair()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = _twoSumSolution.TwoSum(nums, target);

        Assert.Equal(new[] { 0, 1 }, result);
    }

    [Fact]
    public void EdgeCase_EmptyArray_ReturnsEmpty()
    {
        int[] nums = { };
        int target = 0;
        int[] result = _twoSumSolution.TwoSum(nums, target);

        Assert.Empty(result);
    }

    [Fact]
    public void DuplicateNumbers_FindsCorrectIndices()
    {
        int[] nums = { 3, 3 };
        int target = 6;
        int[] result = _twoSumSolution.TwoSum(nums, target);

        Assert.Equal(new[] { 0, 1 }, result);
    }

    [Fact]
    public void NoSolution_ReturnsEmpty()
    {
        int[] nums = { 1, 2, 3 };
        int target = 7;
        int[] result = _twoSumSolution.TwoSum(nums, target);

        Assert.Empty(result);
    }
}
