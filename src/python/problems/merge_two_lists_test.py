# https://leetcode.com/problems/merge-two-sorted-lists/

from typing import Optional
from models.list_node import ListNode
from core.problem_base import *

class MergeTwoLists(ProblemBase):
    def Solution(self, list1: Optional[ListNode], list2: Optional[ListNode]) -> Optional[ListNode]:
        result = ListNode(0)
        current = result

        while list1 and list2:
            if list1.val <= list2.val:
                current.next = list1
                list1 = list1.next
            else:
                current.next = list2
                list2 = list2.next

            current = current.next

        current.next = list1 if list1 else list2

        return result.next

if __name__ == '__main__':
    # TestGen(MergeTwoLists) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    MergeTwoLists().Solution(ListNode(1, ListNode(2, ListNode(4))), ListNode(1, ListNode(3, ListNode(4))))
