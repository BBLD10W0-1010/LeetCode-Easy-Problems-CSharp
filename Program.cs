using System.Text;
using static ConsoleApp1.Solution_21;
namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            var list1 = CreateList(new[] { 1, 2, 4 });
            var list2 = CreateList(new[] { 1, 3, 4 });

            var solution = new Solution_21();
            var result = solution.MergeTwoLists(list1, list2);

            PrintList(result);
        }

        private static ListNode CreateList(int[] values)
        {
            var dummy = new ListNode();
            var current = dummy;

            foreach (var value in values)
            {
                current.next = new ListNode(value);
                current = current.next;
            }

            return dummy.next;
        }

        private static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val);

                if (head.next != null)
                    Console.Write(" -> ");

                head = head.next;
            }
        }
    }


    public class Solution
    {
        public int RomanToInt(string s)
        {
            var dict = new Dictionary<string, int>() { { "I", 1 }, { "V", 5 }, { "X", 10 }, { "L", 50 }, { "C", 100 }, { "D", 500 }, { "M", 1000 } };
            int ansNum = 0;
            for(int i = 0; i < s.Length-1; i++)
            {
                dict.TryGetValue(s[i].ToString(), out var val1);
                dict.TryGetValue(s[i + 1].ToString(), out var val2);
                if (val1 < val2)
                {
                    ansNum -= val1;
                }
                else
                {
                    ansNum += val1;
                }
            }
            dict.TryGetValue(s[s.Length - 1].ToString(), out var last);
            ansNum += last;
            return ansNum;
        }
    }
    public class Solution_14
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                prefix = CommonPrefix(prefix, strs[i]);
            }
            return prefix;
        }
        public string CommonPrefix(string firstWord, string secondWord)
        {
            var minlen = Math.Min(firstWord.Length, secondWord.Length);
            var pref = "";
            int i = 0;

            while ((i < minlen ) && (firstWord[i] == secondWord[i]))
            {
                pref += firstWord[i];
                i++;
            }
            return pref;
        }
    }

    public class Solution_20
    {
        public bool IsValid(string s)
        {
            Stack<char> chars = new();
            foreach(char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    chars.Push(c);
                }
                else
                {
                    chars.TryPeek(out var res1);
                    
                        if ((res1 == '(' && c == ')') || (res1 == '{' && c == '}') || (res1 == '[' && c == ']'))
                        {
                            chars.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    
                }
            }
            if (chars.Count == 0) { return true; }
            else
            {
                return false;
            }
        }
    }
    public class Solution_21
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode(0, null);
            ListNode tail = dummy;
            while (list2 != null && list1 != null)
            {
                if (list1.val >= list2.val)
                {
                    tail.next = list2;
                    
                    list2 = list2.next;
                }
                else
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                tail = tail.next;
            }
            if (list1 != null)
            {
                tail.next = list1;
            }
            else if (list2 != null)
            {
                tail.next = list2;
            }
            return dummy.next;
        }
    }

    public class Solution_26
    {
        public int RemoveDuplicates(int[] nums)
        {
            var pointerOnPosition = 0;
            var currentNum = -1000;
            for (int i = 0; i < nums.Length-1; i++)
            {
                currentNum = nums[i];
                if (currentNum != nums[i+1])
                {
                    nums[pointerOnPosition] = currentNum;
                    pointerOnPosition++;
                }
            }
            nums[pointerOnPosition++] = nums[nums.Length-1];
            return pointerOnPosition;
        }
    }
    public class Solution_27
    {
        public int RemoveElement(int[] nums, int val)
        {
            var pointerOfPosition = 0;
            var currentNum = -1000;
            for (int i = 0; i < nums.Length-1; i++)
            {
                currentNum = nums[i];
                if (currentNum != val)
                {
                    nums[pointerOfPosition++] = currentNum;
                }
            }
            if (nums.Length != 0 && nums[nums.Length-1] != val )
            {
                nums[pointerOfPosition++] = nums[nums.Length - 1];
            }
            return pointerOfPosition;
        }
    }
    public class Solution_28
    {
        public int StrStr(string haystack, string needle)
        {
            if (haystack == needle)
            {
                return 0;
            }
            for (int i=0; i < haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }
            return -1;
        }
    }
    public class Solution_35
    {
        public int SearchInsert(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var tmp = -10000; //value doesn`t matter - ii will be overwritten. Value is needed to store last position of search - thus giving us the point where value can be set so list will remain sorted;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
                tmp = left;
            }
            return tmp;
        }
    }

    //I think it was the first one which I solved first try
    //Idea is to traverse string from end - saves a lot of time and we need only to look out for some edge cases such as test #2 on leetcode
    public class Solution_58
    {
        public int LengthOfLastWord(string s)
        {
            int length = 0;
            for (int i = s.Length-1; i>=0; i--)
            {
                if (s[i] == ' ' && length != 0) 
                {
                    return length;
                }
                else if (s[i] != ' ')
                {
                    length++;
                }
            }
            return length;
        }
    }

    //Done on first try
    //Idea is to look at all possible situations, there are:
    //1. Last digit is not a nine - just add a 1 to num and return digits
    //2. Last digit is nine and others are nine or some are nine - you need to start from end (as we read numbers from right to left) and try to find 
    //a digit that is not a nine =) but if you see nine again - just turn it to 0 and go forward. Make an else clause to this - because if we see some other digit
    //we just need to add 1 that we collected from 9s before.
    public class Solution_66
    {
        public int[] PlusOne(int[] digits)
        {
            int[] ans = new int[digits.Length + 1];
           
            if (digits[digits.Length-1] < 9)
            {
                digits[digits.Length - 1] += 1;
                return digits;
            }
            if (digits[digits.Length - 1] == 9)
            {
                digits[digits.Length - 1] = 0;
                for(int i = digits.Length - 2; i>= 0; i--)
                {
                    if (digits[i] == 9 )
                    {
                        digits[i] = 0;
                    }
                    else
                    {
                        digits[i]++;
                        break;
                    }
                }
                if (digits[0] == 0)
                {
                    ans[0] = 1;
                    ans.Concat(digits);
                    return ans;
                }
            }
            return digits;
        }
    }

    class MyFile
    {
        public static string Decode(string textWithWrongEncoding, Encoding? rightEncoding = null, Encoding? wrongEncoding = null)
        {
            if (rightEncoding is null)
            {
                rightEncoding = Encoding.UTF8;
            }
            if (wrongEncoding is null)
            {
                wrongEncoding = Encoding.GetEncoding(437);
            }
            return rightEncoding.GetString(wrongEncoding.GetBytes(textWithWrongEncoding));
        }
    }
    class StatsCalculator
    {
        public static string Process(string input)
        {
        // Ваш код
                var inputList = input.Split(" ");
                List<int> intinp = new List<int>();
                foreach (var inpp in inputList)
                {
                    intinp.Add(Convert.ToInt32(inpp));
                }
                int cntPlus = 0;
                int cntMinus = 0;
                int cntZero = 0;
                foreach ( int inp in intinp){
                    if (inp == 0)
                    {
                        cntZero++;
                    }
                    else if (inp > 0)
                    {
                        cntPlus++;
                    }
                    else
                    {
                        cntMinus++;
                    }
                }
            return $"выше нуля: {cntPlus}, ниже нуля: {cntMinus}, равна нулю: {cntZero}";
            }
        }
}
