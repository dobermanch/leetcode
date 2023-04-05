# https://leetcode.com/problems/longest-palindromic-substring
class LongestPalindromeSubstring:
    def Solution(self, s: str) -> str:
        def isPalindrome(s, left, right) -> str:
            while left >= 0 and right < len(s) and s[left] == s[right]:
                left -= 1
                right += 1
            return s[left + 1:right]

        result = ""

        for i in range(len(s)):
            p1 = isPalindrome(s, i, i)
            p2 = isPalindrome(s, i, i + 1)
            result = max(result, p1, p2, key=lambda x: len(x))

        return result


LongestPalindromeSubstring().Solution("babad")
