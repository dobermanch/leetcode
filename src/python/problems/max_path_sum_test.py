# https://leetcode.com/problems/binary-tree-maximum-path-sum/

from typing import Optional
from models.tree_node import TreeNode
from core.problem_base import *

class MaxPathSum(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        result = [root.val]

        def Dfs(node) -> int:
            if not node:
                return 0

            left = Dfs(node.left)
            right = Dfs(node.right)

            nodeMax = max(node.val + left, node.val + right)
            nodeMax = max(nodeMax, node.val)

            result[0] = max(result[0], nodeMax)
            result[0] = max(result[0], left + right + node.val)

            return nodeMax

        Dfs(root)

        return result[0]

if __name__ == '__main__':
    # TestGen(MaxPathSum) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    MaxPathSum().Solution(TreeNode(1, TreeNode(2), TreeNode(3)))
