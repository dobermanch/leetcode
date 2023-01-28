public class ReverseList {

    public static void Run(){
        var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
    }

    private static ListNode Run(ListNode head) {
        var result = head;
        var current = result.next;
        do
        {
            var next = current.next;

            current.next = result;
            result = current;
            current = next;
        }
        while (current != null);

        return result;
    }
}
