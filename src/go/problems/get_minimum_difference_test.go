// https://leetcode.com/problems/minimum-absolute-difference-in-bst

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type GetMinimumDifference struct{}

func TestGetMinimumDifference(t *testing.T) {
	gen := core.TestSuite[GetMinimumDifference]{}
	gen.Add(func(tc *core.TestCase) {
		root := &TreeNode{
			Val:   10,
			Left:  &TreeNode{Val: 0, Left: &TreeNode{Val: 4}},
			Right: &TreeNode{Val: 48, Left: &TreeNode{Val: 16}, Right: &TreeNode{Val: 56}},
		}
		tc.Param(root).Result(6)
	}).Run(t)
}

func (GetMinimumDifference) Solution(root *TreeNode) int {
	stack := []*TreeNode{}
	diff := math.MaxInt

	node := root
	var prevNode *TreeNode
	for node != nil || len(stack) > 0 {
		if node != nil {
			stack = append(stack, node)
			node = node.Left
		} else {
			pop := stack[len(stack)-1]
			stack = stack[:len(stack)-1]

			if prevNode != nil {
				newDiff := pop.Val - prevNode.Val
				if newDiff < diff {
					diff = newDiff
				}
			}

			prevNode = pop
			node = pop.Right
		}
	}

	return diff
}
