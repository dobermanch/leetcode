# https://leetcode.com/problems/spiral-matrix-ii/
from core.problem_base import *

class SpiralOrder2(ProblemBase):
    def Solution(self, n: int) -> list[list[int]]:
        martix = [[0] * n for _ in range(n)]

        x, y = 0, 0
        dx, dy = 1, 1
        count = 1
        target = n*n

        while count <= target:
            martix[y][x] = count
            count += 1

            if y == dy - 1 and x < n - dx:
                x += 1
            elif x == n - dx and y < n - dy:
                y += 1
            elif x > dx - 1:
                x -= 1
            elif y > dy:
                y -= 1
                if y == dy and x == dx - 1:
                    dx += 1
                    dy += 1

        return martix


if __name__ == '__main__':
    TestGen(SpiralOrder2) \
        .Add(lambda tc: tc.Param(3).Result([[1,2,3],[8,9,4],[7,6,5]])) \
        .Add(lambda tc: tc.Param(1).Result([[1]])) \
        .Run()
