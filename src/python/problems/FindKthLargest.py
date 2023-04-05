#https://leetcode.com/problems/kth-largest-element-in-an-array/
from heapq import heappop, heappush, heapify

class FindKthLargest:
    def Solution(self, nums: list[int], k: int) -> int:
        queue = []

        for num in nums:
            heappush(queue, num * -1)

        while queue:
            num = heappop(queue)
            k -= 1
            if k <= 0:
                return num * -1

        return 0
    
    def Solution1(self, nums: list[int], k: int) -> int:
        def Sort(left, right, target):
            index = left
            for i in range(left, right):
                if nums[i] <= nums[right]:
                    nums[index], nums[i] = nums[i], nums[index]
                    index += 1

            nums[index], nums[right] = nums[right], nums[index]

            if index > target:
                return Sort(left, index - 1, target)
            
            if index < target:
                return Sort(index + 1, right, target)

            return nums[index]


        return Sort(0, len(nums) - 1, len(nums) - k)


FindKthLargest().Solution([3,2,3,1,2,4,5,5,6], 4)
