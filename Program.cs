using System.Collections;
using System.Numerics;
using System.Text;
using static ConsoleApp1.Solution_83;
using static ConsoleApp1.Solution_94;
namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            var sl = new Solution_219();
            sl.ContainsNearbyDuplicate([ 1, 0, 1, 1 ], 1);
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

    public class Solution_69
    {
        public int MySqrt(int x)
        {
            int left = 2;
            int right = x/2;
            int ans = 1;
            if (x==0 || x == 1)
            {
                return x;
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                long sqr = (long)mid * mid;
                if (sqr == x)
                {
                    return mid;
                }
                else if (sqr > x)
                {
                    right = mid - 1;
                }
                else
                {
                    ans = mid;
                    left = mid + 1;
                }

            }
            return ans;

        }
    }
    //fibonachi through iterations - recursion gives TLE
    public class Solution_70
    {
        public int ClimbStairs(int n)
        {
            int first = 1;
            int second = 2;
            int ans = 3;
            if (n == 1) { return first; }
            if (n == 2) { return second; }
            for (int steps = 3; steps <= n; steps++)
            {
                int next = first + second;
                first = second;
                second = next;
            }
            return second;
        }
    }


    public class Solution_83
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode tail = head;
            while (tail != null && tail.next != null)
            {

                if (tail.val == tail.next.val)
                {
                    tail.next = tail.next.next;
                }
                else
                {
                    tail = tail.next;
                }
                
            }
            return head;
        }

    }
    public class Solution_88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int pointerOnNums1End = m - 1;
            int pointerOnNums2End = n - 1;
            int lastPosNum1 = m + n - 1;

            while (pointerOnNums2End >= 0)
            {
                if (pointerOnNums1End >= 0 && nums1[pointerOnNums1End] > nums2[pointerOnNums2End])
                {
                    nums1[lastPosNum1] = nums1[pointerOnNums1End];
                    pointerOnNums1End--;
                }
                else
                {
                    nums1[lastPosNum1] = nums2[pointerOnNums2End];
                    pointerOnNums2End--;
                }
                lastPosNum1--;
            }
           
        }
    }

    public class Solution_94
    {
        public class TreeNode
        {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                     }
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> lst = new List<int>();
            Helper(root, lst);
            return lst;

            
        }
        public void Helper(TreeNode root, IList<int> lst)
        {
            if (root != null)
            {
                Helper(root.left, lst);
                lst.Add(root.val);
                Helper(root.right, lst);
            }
        }
    }
    public class Solution_100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return Helper(p, q);
        }
        
        public bool Helper(TreeNode root, TreeNode secondRoot)
        {
            if (root == null && secondRoot == null)
            {
                return true;
            }
            if (root == null || secondRoot == null)
            {
                return false;
            }
            return Helper(root.left, secondRoot.left) && Helper(root.right, secondRoot.right) && root.val == secondRoot.val;
        }
    }
    public class Solution_101
    {
        public bool IsSymmetric(TreeNode root)
        {
            TreeNode lt = root.left;
            TreeNode rt = root.right;
            return IsSymmetric(lt, rt);

        }

        public bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null || right == null)
            {
                return false;
            }
            if (left.val != right.val)
            {
                return false;
            }
            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }
    }

    //Actually - this was quite easy. Somehow wrote this without any second thoughts - just bam, and it`s done
    public class Solution_104
    {
        public int MaxDepth(TreeNode root)
        {
            return Helper(root, 0);
        }
        public int Helper(TreeNode root, int depth)
        {
            if (root == null)
            {
                return depth;
            }
            return Math.Max(Helper(root.left, depth + 1), Helper(root.right, depth + 1));
        }
    }
    public class Solution_108
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            return CreateTree(nums, start, end);
        }

        public TreeNode CreateTree(int[] nums,int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            return new TreeNode(nums[mid], CreateTree(nums, start, mid - 1), CreateTree(nums, mid + 1, end));
        }
    }
    public class Solution_110
    {
        public bool IsBalanced(TreeNode root)
        {
            return Helper(root) != -1;
        }

        public int Helper(TreeNode root)
        {
            if (root == null)
            {
               return 0;
            }
            int leftHeight = Helper(root.left);

            if (leftHeight == -1)
            {
                return -1;
            }
            int rightHeight = Helper(root.right);
            if (rightHeight == -1)
            {
                return -1;
            }
            if (Math.Abs(rightHeight-leftHeight) > 1)
            {
                return -1;
            }
            return Math.Max(rightHeight, leftHeight) + 1;
        }
    }
    public class Solution_111
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return Helper(root, 1);

        }
        public int Helper(TreeNode root, int depth)
        {
            if (root.left == null && root.right == null)
            {
                return depth ;
            }

            if (root.left == null)
            {
                return Helper(root.right, depth + 1);
            }
            if (root.right == null)
            {
                return Helper(root.left, depth + 1);
            }
            return Math.Min(Helper(root.left, depth + 1), Helper(root.right, depth + 1));
        }
    }
    public class Solution_118
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var ans = new List<IList<int>>();
            if (numRows == 1)
            {
                ans.Add(new List<int>() { 1 });
                return ans;
            }
            if (numRows == 2)
            {
                ans.Add(new List<int>() { 1 });
                ans.Add(new List<int>() { 1,1 });
                return ans;

            }
            for (int i = 0; i < numRows; i++)
            {
                if (i == 0)
                {
                    ans.Add(new List<int>() { 1 });
                }
                else if (i == 1)
                {
                    ans.Add(new List<int>() { 1, 1 });
                }
                else
                {
                    var lstToAdd = new List<int>() { };
                    for (int k = 0; k <= i; k++)
                    {
                        if (k == 0 || k == i)
                        {
                            lstToAdd.Add(1);
                        }
                        else
                        {
                            lstToAdd.Add(ans[i - 1][k - 1] + ans[i - 1][k]);
                        }
                    }
                    ans.Add(lstToAdd);
                }
            }
            return ans;
        }
    }
    public class Solution_121
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int buy = prices[0];
            foreach (int val in prices)
            {
                if (val > buy)
                {
                    profit = Math.Max(profit, val - buy);
                }
                else
                {
                    buy = val;
                }
            }
            return profit;
        }
    }
    public class Solution_125
    {
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while(left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
    public class Solution_136
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            for(int i=0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
    }
    //what a mess
    public class Solution_141
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            ListNode slowPointer = null;
            ListNode fastPointer = head;
            bool flag = false;
            while (fastPointer != null && slowPointer != fastPointer)
            {
                if (!flag) { slowPointer = head; flag = true; }
                else { slowPointer = slowPointer.next; }

                fastPointer = fastPointer.next;
                if (fastPointer == null)
                {
                    return false;
                }
                fastPointer = fastPointer.next;
                if (fastPointer == null)
                {
                    return false;
                }
            }
            return true;
            
        }
    }
    public class Solution_144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();
            Helper(root, ans);
            return ans;
        }

        public void Helper(TreeNode root, List<int> ans)
        {
            if (root != null)
            {
                ans.Add(root.val);
                Helper(root.left, ans);
                Helper(root.right, ans);
            }

        }
    }
    public class Solution_145
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();
            Helper(root, ans);
            return ans;
        }

        public void Helper(TreeNode root, List<int> ans)
        {
            if (root != null)
            {
                Helper(root.left, ans);
                Helper(root.right, ans);
                ans.Add(root.val);
            }
        }
    }
    public class Solution_160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            
            ListNode headBstart = headB;
            while (headA != null)
            {
                while (headB != null)
                {
                    if (headB == headA)
                    {
                        return headA;
                    }
                    headB = headB.next;
                }
                headA = headA.next;
                headB = headBstart;
            }
            return null;
        }
    }
    public class Solution_168
    {
        public static string ConvertToTitle(int columnNumber)
        {
            StringBuilder ans = new();
            while (columnNumber > 0)
            {
                columnNumber--;
                ans.Insert(0, Convert.ToChar(columnNumber % 26 + 65));
                columnNumber /= 26;
            }
            return ans.ToString();
        }
    }
    public class Solution_169
    {
        public int MajorityElement(int[] nums)
        {
            int votes = 0;
            int candidate = -1;
            int cnt = 0;
            for(int i=0; i< nums.Length; i++)
            {
                if (votes == 0)
                {
                    candidate = nums[i];
                    votes = 1;
                }
                else
                {
                    if (nums[i] == candidate)
                    {
                        votes++;
                    }
                    else
                    {
                        votes--;
                    }
                }
            }
            for (int i=0; i<nums.Length; i++)
            {
                if (candidate == nums[i])
                {
                    cnt++;
                }
                if (cnt > nums.Length / 2)
                {
                    return candidate;
                }
                
            }
                return -80085;
        }
    }
    //fiddling with numbers (-1+1-1+1-1+1-1+1)
    public class Solution_171
    {
        public int TitleToNumber(string columnTitle)
        {
            int ans = 0;
            for (int i = 0; i<columnTitle.Length; i++)
            {
                ans += (int)Math.Pow(26, columnTitle.Length -1 - i) * (Convert.ToInt32(columnTitle[i])-64);
            }
            return ans;
        }
    }
    //that`s not so good - but it`s only four times the exec time from best solution =)
    public class Solution_190
    {
        public int ReverseBits(int n)
        {
            
            StringBuilder ans = new StringBuilder(Convert.ToString(n,2).PadLeft(32,'0'));
            for(int i = 0; i < ans.Length / 2; i++)
            {
                char tmp = ans[i];
                ans[i] = ans[ans.Length - 1 - i];
                ans[ans.Length -1 - i] = tmp;
            }
            return Convert.ToInt32(ans.ToString(),2);

        }
    }
    //fun with bits
    public class Solution_191
    {
        public int HammingWeight(int n)
        {
            int ans = 0;
            while (n > 0)
            {
                var firstBit = n & 1;
                if (firstBit == 1)
                {
                    ans++;
                }
                n >>= 1; 
            }
            return ans;
        }
    }
    //could be more optimal if I were checking containing of key in dict, not in a list
    public class Solution_202
    {
        public bool IsHappy(int n)
        {
            int tmp = n;
            List<int> wereBefore = new();
            while(n != 1)
            {
                n = SumOfSquaredDigits(n);
                
                if (n == tmp)
                {
                    return false;
                }
                if (wereBefore.Contains(n))
                {
                    return false;
                }
                wereBefore.Add(n);
            }
            return true;
        }

        public int SumOfSquaredDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }
            return sum;
        }
    }
    public class Solution_203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new(0, head);
            var current = dummy;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return dummy.next;
        }

    }
    public class Solution_205
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> map = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.TryGetValue(s[i], out char idgaf))
                {
                    if (idgaf != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (map.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    map[s[i]] = t[i];
                   
                }
            }
            return true;
        }
    }
    public class Solution_206
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            ListNode next;
            while(curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
    }
    public class Solution_217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> distinct = new();
            for (int i = 0; i< nums.Length; i++)
            {
                if (!distinct.TryAdd(nums[i], 1))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Solution_219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> distinct = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!distinct.TryAdd(nums[i], i))
                {
                    if (Math.Abs(i - distinct[nums[i]]) <= k)
                    {
                        return true;
                    }
                    else
                    {
                        distinct[nums[i]] = i;
                    }
                }
            }
            return false;
        }
    }
    //brochacho watahelli is this shi - why would you make stack out of queues - nevertheless it`s done
    public class Solution_225
    {
        public class MyStack
        {
            public Queue<int> queue;
            public Queue<int> queue2;
            public MyStack()
            {
                this.queue = new();
                this.queue2 = new();
            }

            public void Push(int x)
            {
                queue.Enqueue(x);
            }

            public int Pop()
            {
                while (queue.Count > 1){
                    queue2.Enqueue(queue.Dequeue());
                }
                var tnp = queue.Dequeue();
                while (queue2.Count > 0)
                {
                    queue.Enqueue(queue2.Dequeue());
                }
                return tnp;
            }

            public int Top()
            {
                while (queue.Count > 1)
                {
                    queue2.Enqueue(queue.Dequeue());
                }
                var tnp = queue.Peek();
                queue2.Enqueue(queue.Dequeue());
                while (queue2.Count > 0)
                {
                    queue.Enqueue(queue2.Dequeue());
                }
                return tnp;
            }

            public bool Empty()
            {
                return !(queue.Count > 0);
            }
        }
    }

    public class Solution_226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            Helper(root);
            return root;
        }

        public void Helper(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            Helper(root.left);
            Helper(root.right);
        }
    }
}
