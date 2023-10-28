// https://leetcode.com/problems/letter-combinations-of-a-phone-number/

function letterCombinations(digits: string): string[] {
    if (digits.length <= 0) {
        return [];
    }

    var map = {
        '2':"abc", '3':"def",
        '4':"ghi", '5':"jkl", '6':"mno",
        '7':"pqrs", '8':"tuv", '9':"wxyz"
    };

    var result: string[] = [];
    var temp: string[] = [];

    function search(digitsIndex: number, tempIndex: number) {
        if (digitsIndex >= digits.length) {
            result.push(''.concat(...temp));
            return
        }
        
        for (const ch of map[digits[digitsIndex]]) {
            temp[tempIndex] = ch;
            search(digitsIndex + 1, tempIndex + 1);
        }
    }

    search(0, 0);

    return result;
};